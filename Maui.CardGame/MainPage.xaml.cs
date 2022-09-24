namespace Maui.CardGame;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        Suffle();

    }

    private void Suffle()
    {
        var numbers = from num in Enumerable.Range(1, 45)
                      orderby Random.Shared.Next()
                      select num;

        var pickNumbers = numbers.Take(6).OrderBy(x => x).ToList();

        int i = 0;
        foreach (Button button in this.cardStackLayout.Children)
        {
            button.ClassId = pickNumbers[i].ToString();
            i++;
        }
    }

    private async void SuffleButton_Clicked(object sender, EventArgs e)
    {
        foreach (Button button in this.cardStackLayout.Children)
        {
            button.Text = "";

            if (button.BackgroundColor == Colors.White)
            {
                await Task.WhenAll(
                    button.ScaleTo(0.8, 25, Easing.SinInOut),
                    button.RotateYTo(180, 25, Easing.SinOut)
                    );

                button.BackgroundColor = Colors.LightGray;

                await Task.WhenAll(
                    button.ScaleTo(1, 25, Easing.SinIn),
                    button.RotateYTo(180, 25, Easing.SinIn)
                    );

                button.BackgroundColor = Colors.White;
                button.Text = "◇◆";
            }
            else
            {
                await Task.WhenAll(
                    button.ScaleTo(0.8, 25, Easing.SinInOut),
                    button.RotateYTo(180, 25, Easing.SinOut)
                    );

                button.BackgroundColor = Colors.LightGray;

                await Task.WhenAll(
                    button.ScaleTo(1, 25, Easing.SinIn),
                    button.RotateYTo(180, 25, Easing.SinIn)
                );

                button.BackgroundColor = Colors.White;
                button.Text = "◇◆";
            }
        }

        Suffle();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Button selectButton = (Button)sender;

        if (selectButton.BackgroundColor == Colors.White)
        {
            selectButton.RotateYTo(360, 200);
            selectButton.BackgroundColor = Colors.LightGray;
            selectButton.Text = selectButton.ClassId;
        }
        else
        {
            selectButton.RotateYTo(180, 200);
            selectButton.Text = "◇◆";
            selectButton.BackgroundColor = Colors.White;
        }
    }
}

