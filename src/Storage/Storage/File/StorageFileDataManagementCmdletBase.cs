﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using Microsoft.WindowsAzure.Commands.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using Microsoft.Azure.Storage.DataMovement;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading.Tasks;

    public abstract class StorageFileDataManagementCmdletBase : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Stores the default concurrent task count which is 10.
        /// </summary>
        private const int DefaultConcurrentTaskCount = 10;

        public const long sizeTB = (long)1024 * 1024 * 1024 * 1024;

        protected const int size4MB = 4 * 1024 * 1024;

        /// <summary>
        /// Stores the transfer manager instance.
        /// </summary>
        protected ITransferManager TransferManager
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets or sets whether to force overwrite the existing file.
        /// </summary>
        [Parameter(HelpMessage = "Force to overwrite the existing file.")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="source">Indicating the source.</param>
        /// <param name="destination">Indicating the destination.</param>
        /// <returns>Returns a value indicating whether to overwrite.</returns>
        protected bool ConfirmOverwrite(object source, object destination)
        {
            return this.Force || this.OutputStream.ConfirmAsync(string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination))).Result;
        }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="source">Indicating the source.</param>
        /// <param name="destination">Indicating the destination.</param>
        /// <returns>Returns a value indicating whether to overwrite.</returns>
        protected async Task<bool> ConfirmOverwriteAsync(object source, object destination)
        {
            return this.Force || await this.OutputStream.ConfirmAsync(string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination)));
        }

        protected override void BeginProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoBeginProcessing();
            }
        }

        protected void DoBeginProcessing()
        {
            base.BeginProcessing();

            this.TransferManager = TransferManagerFactory.CreateTransferManager(this.GetCmdletConcurrency());
            OutputStream.ConfirmWriter = (target, query, caption) => ShouldContinue(query, caption);
        }

        protected override void EndProcessing()
        {
            if (!AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        protected void DoEndProcessing()
        {
            try
            {
                base.EndProcessing();
                this.WriteTaskSummary();
            }
            finally
            {
                this.TransferManager = null;
            }
        }

        protected SingleTransferContext GetTransferContext(ProgressRecord record, long totalTransferLength)
        {
            SingleTransferContext transferContext = new SingleTransferContext();
            transferContext.ClientRequestId = CmdletOperationContext.ClientRequestId;
            if (this.Force)
            {
                transferContext.ShouldOverwriteCallbackAsync = TransferContext.ForceOverwrite;
            }
            else
            {
                transferContext.ShouldOverwriteCallbackAsync = ConfirmOverwriteAsync;
            }

            transferContext.ProgressHandler = new TransferProgressHandler((transferProgress) =>
            {
                if (record != null)
                {
                    // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                    record.PercentComplete = (totalTransferLength == 0) ? 100 : (int)(transferProgress.BytesTransferred * 100 / totalTransferLength);
                    record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, record.PercentComplete);
                    this.OutputStream.WriteProgress(record);
                }
            });

            return transferContext;
        }

        // Dynamic Parameters which are only available on Windows.
        public class WindowsOnlyParameters
        {
            [Parameter(HelpMessage = "Keep the source File SMB properties (File Attributes, File Creation Time, File Last Write Time) in destination File. This parameter is only available on Windows.")]
            public SwitchParameter PreserveSMBAttribute { get; set; }
        }
    }
}
