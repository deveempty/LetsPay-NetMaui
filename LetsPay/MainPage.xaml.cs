namespace LetsPay;

public partial class MainPage : ContentPage
{
	decimal bill;
	int tip;
	int numberPersons = 1;

	public MainPage()
	{
		InitializeComponent();
	}

    void txtBill_Completed(System.Object sender, System.EventArgs e)
    {
		bill = decimal.Parse(txtBill.Text);
		CalculateTotal();
    }

    private void CalculateTotal()
    {
        
        var totalTip = (bill * tip) / 100; // total tip
        var tipByPerson = (totalTip / numberPersons);
        lblTipByPerson.Text = $"{tipByPerson:C}";

        //subtotal
        var subtotal = (bill / numberPersons);
        lblSubtotal.Text = $"{subtotal:C}";

        //total
        var totalByPerson = (bill + totalTip) / numberPersons;
        lblTotal.Text = $"{totalByPerson:C}";

    }

    void sldTip_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        if(sender is Button)
        {
            var btn = (Button)sender;
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    void btnMinus_Clicked(System.Object sender, System.EventArgs e)
    {
        if(numberPersons > 1)
        {
            numberPersons--;
        }
        lblNoPerons.Text = numberPersons.ToString();
        CalculateTotal();
    }

    void bntPlus_Clicked(System.Object sender, System.EventArgs e)
    {
        numberPersons++;
        lblNoPerons.Text = numberPersons.ToString();
        CalculateTotal();
    }
}


