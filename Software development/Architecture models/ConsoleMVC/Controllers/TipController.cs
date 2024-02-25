using ConsoleMVC.Models;
using ConsoleMVC.Views;

namespace ConsoleMVC.Controllers
{
    public class TipController
    {
        public void Execute()
        {
            var form = new TipForm();

            // 1. User fills in a form
            form.Submit();

            // 2. Controller takes the request and sends data from the view to the model (service layer)
            var tip = new Tip { Amount = form.Amount, Percentage = form.TipPercentage };

            // 3. The service layer returns some data that we send back to the view
            var view = new TipView { Tip = tip.Value, Total = tip.Total };

            // 4. Return a response to the user
            view.Render();
        }
    }
}
