using DataAccess.Models;
using MuhasebeApp.Views.TakenCheckPages;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace MuhasebeApp.Views.CheckPages;

public partial class AddCheck : ContentPage
{
    public AddCheck()
    {
        InitializeComponent();
    }

    private long _id = 0;
    private long _ciroEdilenId = 0;
    private bool _alinacakMi = false;
    public AddCheck(long id, bool alinacakMi = false)
    {
        InitializeComponent();
        _id = id;
        if (_id > 0)
        {
            _alinacakMi = alinacakMi;
            Getir();
        }

    }
    bool valid = true;

    async void Button_Clicked(object sender, EventArgs e)
    {

        Check check = new Check();

        valid = true;
        if (String.IsNullOrEmpty(CekSira.Text))
        {
            await DisplayAlert("Dikkat", "Çek sırası boş olamaz", "Tamam");
            return;
        }
        if (String.IsNullOrEmpty(HesapNu.Text))
        {
            await DisplayAlert("Dikkat", "Hesap Numarası boş olamaz", "Tamam");
            return;
        }
        if (String.IsNullOrEmpty(CekNu.Text))
        {
            await DisplayAlert("Dikkat", "Çek numarası boş olamaz", "Tamam");
            return;
        }
        if (String.IsNullOrEmpty(Banka.Text))
        {
            await DisplayAlert("Dikkat", "banka  boş olamaz", "Tamam");
            return;
        }
        if (String.IsNullOrEmpty(Sube.Text))
        {
            await DisplayAlert("Dikkat", "Şube boş olamaz", "Tamam");
            return;
        }
        if (ay.SelectedItem == null || (ay.SelectedItem is string) ? String.IsNullOrEmpty(ay.SelectedItem.ToString()) : false)
        {
            await DisplayAlert("Dikkat", "Vade Ayı zorunlu", "Tamam");
            return;
        }
        if (String.IsNullOrEmpty(Tutar.Text))
        {
            await DisplayAlert("Dikkat", "Tutar zorunlu", "Tamam");
            return;
        }
        if (String.IsNullOrEmpty(kimdenCiro.Text))
        {
            await DisplayAlert("Dikkat", "Ciro edilecek boş", "Tamam");
            return;

        }
        if (String.IsNullOrEmpty(kimden.Text))
        {
            await DisplayAlert("Dikkat", "Çek alınan  boş", "Tamam");
            return;
        }

        if (!Resmi.IsChecked && !Gresmi.IsChecked && !kendimeCiro.IsChecked)
        {
            await DisplayAlert("Dikkat", "Çekin Durumu? Resmi- Gresmi seçimi yapınız", "Tamam");
            return;
        }
       

        check.cekSira = CekSira.Text;
        check.id = _id == 0 ? DateTime.Now.Ticks : _id;
        check.hesapNu = HesapNu.Text;
        check.cekNu = CekNu.Text;
        check.cekTuru = CekTuru.Text;
        check.bankasi = Banka.Text;
        check.subesi = Sube.Text;
        check.kimdenAlindi = kimden.Text;
        check.kimeCiroEdildi = kimdenCiro.Text;
        check.vadeAyi = ay.SelectedItem != null ? ay.SelectedItem.ToString() : "";
        check.cekinAlindigiTarih = alinmaTarihi.Date;
        check.cikisTarihi = cikisTarihi.Date;
        check.tutar = Tutar.Text;//null olabilir
        check.vadeTarihi = vadeTarihi.Date;//null olabilir


        if (Resmi.IsChecked)
            check.yasalMi = "Resmi";//null olabilir
        else if (Gresmi.IsChecked)
            check.yasalMi = "G.Resmi";//null olabilir
        else if (kendimeCiro.IsChecked)
            check.yasalMi = "Kendime";//null olabilir


        check.alınacakMiOdenecekMi = _alinacakMi;
       
        Libs.AppConst.AddCheck(check); ///LOCAL DB


        try
        {
            if (true)
            {
                if (_ciroEdilenId != 0)
                {
                    if (_alinacakMi)
                        await Navigation.PushAsync(new PersonalChecks());
                    else
                        await Navigation.PushAsync(new TakenChecks());
                }

            }
            else
            {
            }
        }
        catch (Exception ex)
        {

        }
    }


    async void Getir()
    {
        Check check = new Check();
         check = Libs.AppConst.GetCheck(_id);  ///LOKAL DB
     
        this.Dispatcher.Dispatch(() =>
        {
            CekSira.Text = check.cekSira;
            HesapNu.Text = check.hesapNu;
            CekNu.Text = check.cekNu;
            CekTuru.Text = check.cekTuru;
            Banka.Text = check.bankasi;
            Sube.Text = check.subesi;
            kimden.Text = check.kimdenAlindi;
            kimdenCiro.Text = check.kimeCiroEdildi;
            ay.SelectedItem = check.vadeAyi;
            alinmaTarihi.Date = check.cekinAlindigiTarih;

            if (check.cikisTarihi != null)
                cikisTarihi.Date = check.cikisTarihi.Value;

            if (!String.IsNullOrEmpty(check.tutar))
                Tutar.Text = check.tutar;
            else
                Tutar.Text = "";

            if (check.KendimeCiro.HasValue)
                kendimeCiro.IsChecked = check.KendimeCiro.Value;

            if (check.yasalMi == "Resmi")
                Resmi.IsChecked = true;
            else
                Gresmi.IsChecked = true;
            vadeTarihi.Date = check.vadeTarihi;
        });


    }
    async void HepsinGetir(object sender, EventArgs e)
    {
        try
        {
            running.IsVisible = true;
            //HelperClass.CloseKeyboard();
            string searchText = ((SearchBar)sender).Text;
            List<Check> checks = new List<Check>();
      
            var customFont = Microsoft.Maui.Font.SystemFontOfSize(10);
            var fontFamily = "input.ttf"; // Bu, eklediğiniz fontun adı olmalı

            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                customFont = Microsoft.Maui.Font.OfSize(fontFamily, 10);
            }
            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                customFont = Microsoft.Maui.Font.OfSize(fontFamily, 10);
            }
            //Thread.Sleep(1000);
            Thread.Sleep(500);
            mainStackLayout.Clear();
            this.Dispatcher.Dispatch( () =>
            {

                StackLayout horizontalStackLayout;
                ImageButton imageButton;
                StackLayout verticalStackLayout;
                Label nameLabel;
                Label alinmaTarihi;
                Label vadeTarihi;
                StackLayout verticalStackLayout2;
                Label amountLabel;
                Label amountLabel2;

                int i = 0;

                foreach (var dataItem in checks)
                {
                    horizontalStackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Center
                    };

                    imageButton = new ImageButton
                    {
                        Source = "cek.jpg",
                        Aspect = Aspect.Fill,
                        WidthRequest = 50,
                        HeightRequest = 50,
                        CornerRadius = 10,
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(5),

                    };
                    imageButton.Clicked += (sender, e) =>
                    {
                        ImageButton_Clicked(sender, e, dataItem.id);
                    };

                    horizontalStackLayout.Children.Add(imageButton);

                    verticalStackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = LayoutOptions.Center
                    };

                    nameLabel = new Label
                    {
                        Text = dataItem.kimdenAlindi.Length > 15 ? dataItem.kimdenAlindi.Substring(0, 15) + "..." : dataItem.kimdenAlindi,
                        HorizontalOptions = LayoutOptions.StartAndExpand,// Aligns label to the left
                        Margin = new Thickness(10, 0, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        FontSize = 10,
                        WidthRequest = 110,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily
                    };
                    verticalStackLayout.Children.Add(nameLabel);
                    alinmaTarihi = new Label
                    {
                        Text = "Alındığı Tar:" + " " + dataItem.cekinAlindigiTarih.ToString("dd.MM.yyyy"),
                        HorizontalOptions = LayoutOptions.FillAndExpand,// Aligns label to the left
                        Margin = new Thickness(10, 0, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        FontSize = 10,
                        WidthRequest = 150,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily
                    };
                    verticalStackLayout.Children.Add(alinmaTarihi);
                    vadeTarihi = new Label
                    {
                        Text = "Vade Tar:" + " " + dataItem.vadeTarihi.ToString("dd.MM.yyyy"),
                        HorizontalOptions = LayoutOptions.FillAndExpand,// Aligns label to the left
                        Margin = new Thickness(10, 0, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        FontSize = 10,
                        WidthRequest = 150,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily
                    };
                    verticalStackLayout.Children.Add(vadeTarihi);
                    horizontalStackLayout.Children.Add(verticalStackLayout);

                    verticalStackLayout2 = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = LayoutOptions.Start
                    };


                    amountLabel = new Label
                    {
                        Text = $"{dataItem.bankasi}",
                        HorizontalOptions = LayoutOptions.StartAndExpand,// Aligns label to the left
                        Margin = new Thickness(0, 10, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        WidthRequest = 100,
                        FontSize = 10,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily


                    };
                    verticalStackLayout2.Children.Add(amountLabel);

                    amountLabel2 = new Label
                    {
                        Text = $"{dataItem.tutar}" + " " + "₺",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,// Aligns label to the left
                        Margin = new Thickness(0, 5, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        WidthRequest = 100,
                        FontSize = 10,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily

                    };
                    verticalStackLayout2.Children.Add(amountLabel2);
                    horizontalStackLayout.Children.Add(verticalStackLayout2);
                    //horizontalStackLayout.Children.Add(amountLabel);

                    mainStackLayout.Children.Add(horizontalStackLayout);
                }
                running.IsVisible = false;
            });


        }
        catch (Exception ex)
        {
            running.IsVisible = false;
        }

    }
    async void ImageButton_Clicked(object sender, EventArgs e, long id)
    {
        running.IsVisible = true;
        Check check = new Check();
        string apiUrl = "" + id;
        try
        {
            check = Libs.AppConst.GetCheck(id);
            _ciroEdilenId = check.id;
        }
        catch (HttpRequestException ex)
        {
            running.IsVisible = false;

            Console.WriteLine($"Error: {ex.Message}");
        }

        this.Dispatcher.Dispatch( () =>
        {
            kimdenCiro.Text = check.kimdenAlindi;
            if (check.cikisTarihi != null)
                cikisTarihi.Date = check.cikisTarihi.Value;

            if (check.KendimeCiro.HasValue)
                kendimeCiro.IsChecked = check.KendimeCiro.Value;

            if (check.yasalMi == "Resmi")
                Resmi.IsChecked = true;
            else
                Gresmi.IsChecked = true;

            running.IsVisible = false;
        });


    }
    private void myListView_Scrolled(object sender, ScrolledEventArgs e)
    {

    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}