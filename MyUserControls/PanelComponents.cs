using System;
using System.Threading.Tasks;

namespace generateContentForInstructionSimonov.MyUserControls
{
    public partial class PanelComponents : Classes.MyUserControl
    {
        private bool isGenerateComponents = false;
        public PanelComponents()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Вызываем все необходимые методы:
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnLoad(EventArgs e)
        {
            isGenerateComponents = await generateComponents();
            base.OnLoad(e);
        }

        private Task<bool> generateComponents()
        {
            //for (int i = 0; i < 1000000000; i++) 
            //{
            //    System.Threading.Thread.Sleep(10);
            //}
            return TaskEx.FromResult(false);
        }

    }
}
