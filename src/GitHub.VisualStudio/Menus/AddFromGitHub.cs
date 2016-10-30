using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Composition;
using GitHub.Services;
using GitHub.UI;
using GitHub.Extensions;
using System.Diagnostics;
using NullGuard;
using EnvDTE;

namespace GitHub.VisualStudio.Menus
{
    [Export(typeof(IDynamicMenuHandler))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class AddFromGitHub : MenuBase
    {
        private readonly _DTE dte;

        [ImportingConstructor]
        public AddFromGitHub([Import(typeof(SVsServiceProvider))] IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.dte = ServiceProvider.GetService<_DTE>();
        }

        public Guid Guid { get { return GuidList.guidSolutionExplorerContextMenuSet; } }
        public int CmdId { get { return PkgCmdIDList.addFromGitHubCommand; } }

        public void Activate([AllowNull] object data)
        {
            StartFlow(UIControllerFlow.AddFileToSolution);
        }
    }
}
