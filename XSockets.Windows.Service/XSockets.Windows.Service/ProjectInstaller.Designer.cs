namespace XSockets.Windows.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.XSocketsServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.XSocketsInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // XSocketsServiceProcessInstaller
            // 
            this.XSocketsServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.XSocketsServiceProcessInstaller.Password = null;
            this.XSocketsServiceProcessInstaller.Username = null;
            // 
            // XSocketsInstaller
            // 
            this.XSocketsInstaller.ServiceName = "XSockets";
            this.XSocketsInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.XSocketsServiceProcessInstaller,
            this.XSocketsInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller XSocketsServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller XSocketsInstaller;
    }
}