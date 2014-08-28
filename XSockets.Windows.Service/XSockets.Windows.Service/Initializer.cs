using System.ServiceProcess;

namespace XSockets.Windows.Service
{
    public partial class Initializer : ServiceBase
    {
        
        public Initializer()
        {
            InitializeComponent();           
        }

        protected override void OnStart(string[] args)
        {
            new XSockets.Windows.Service.Host.Instance();
        }

        protected override void OnStop()
        {
        }
    }

    
}
