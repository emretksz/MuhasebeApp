using DataAccess.Models;
using MuhasebeApp.Libs;
using System.Text.Json;

namespace MuhasebeApp.Views.CheckPages;

public partial class EndorsementCheck : ContentPage
{
    int count = 0;
    public List<CheckDto> checks { get; set; } = new List<CheckDto>();
    public bool waitFilter = true;
    public EndorsementCheck()
	{
		InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }
    private async Task LoadData()
    {

        try
        {

            await Task.Run(async () =>
            {
                /// apiiiiiiiiiiii
                //  var result =await  ApiServices.GetData<List<CheckDto>>("https..............")
               
            });

          //  checks = Libs.AppConst.CheckList;

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
            if (checks.Count > 0)
            {
               toplamdurum.Text = "Toplam" + " " + checks[0].tutar + "\n" + "Kalan" + " " + checks[0].kalan;
            }
            Thread.Sleep(1000);
            this.Dispatcher.Dispatch(() =>
            {
                ////   template oluşturup çağırabilirim ama şu an böyle kalsın sonra bakarım !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                StackLayout horizontalStackLayout;
                ImageButton imageButton;
                StackLayout verticalStackLayout;
                Label nameLabel;
                Label alinmaTarihi;
                Label vadeTarihi;
                StackLayout verticalStackLayout2;
                StackLayout verticalStackLayout3;
                Label amountLabel;
                Label amountLabel2;
                int i = 0;
                foreach (var dataItem in checks)
                {
                    if (i == 0)
                    {
                        i = 1;
                        continue;
                    }
                    horizontalStackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.FillAndExpand
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
                        ImageButton_Clicked(sender, e, (int)dataItem.id);
                    };

                    horizontalStackLayout.Children.Add(imageButton);

                    verticalStackLayout = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    };

                    nameLabel = new Label
                    {
                        Text = dataItem.kimdenAlindi,
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

                    verticalStackLayout3 = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = LayoutOptions.Start
                    };
                    amountLabel2 = new Label
                    {
                        Text = dataItem.cekSira,
                        HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                        Margin = new Thickness(0, 15, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        WidthRequest = 100,
                        FontSize = 10,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily

                    };
                    verticalStackLayout3.Children.Add(amountLabel2);

                    amountLabel2 = new Label
                    {
                        Text = String.IsNullOrEmpty(dataItem.kimeCiroEdildi) ? "" : dataItem.kimeCiroEdildi.Length > 13 ? dataItem.kimeCiroEdildi.Substring(0, 12) + "..." : dataItem.kimeCiroEdildi,
                        HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                        Margin = new Thickness(0, 5, 0, 0),
                        LineBreakMode = LineBreakMode.WordWrap,
                        WidthRequest = 80,
                        FontSize = 8,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Colors.White,
                        FontFamily = fontFamily

                    };
                    verticalStackLayout3.Children.Add(amountLabel2);

                    horizontalStackLayout.Children.Add(verticalStackLayout2);
                    horizontalStackLayout.Children.Add(verticalStackLayout3);
                    //horizontalStackLayout.Children.Add(amountLabel);

                    mainStackLayout.Children.Add(horizontalStackLayout);
                }
                running.IsVisible = false;
            });
        }

        catch (Exception ex)
        {
            running.IsVisible = false;
            //Thread.Sleep(500);
            // ReLoadData();
        }
    }

    void ImageButton_Clicked(object sender, EventArgs e, int id)
    {

        Navigation.PushAsync(new AddCheck(id, false), false);

        
    }
    void OnMyButtonClick(object sender, EventArgs e)
    {

       // Navigation.PushAsync(new EndorsementCheck(false), false);

    }
    public async void Filtrele(object sender, EventArgs e)
    {
        //HelperClass.CloseKeyboard();
        var ay = Ay.SelectedItem;
        var yıl = Yıl.SelectedItem;
        var key = textim.Text;


        if (ay != null && ay.ToString() == "Tum Aylar")
        {
            ay = "Tumu";
        }
        if (yıl != null && yıl.ToString() == "Tum Yıllar")
        {
            yıl = 0;
        }

        if (waitFilter)
        {
            try
            {
                running.IsVisible = true;
                waitFilter = false;

                        string apiUrl = "";
                        if (String.IsNullOrEmpty(key))
                            apiUrl = "=" + ay + "&yil=" + yıl;
                        else
                            apiUrl = "" + ay + "&yil=" + yıl + "&key=" + key;

                        try
                        {
                            checks = await ApiServices.GetData<List<CheckDto>>(apiUrl);
                            //listem.ItemsSource= checks;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

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
                if (checks.Count > 0)
                    {
                        toplamdurum.Text = "Toplam " + " " + checks[0].tutar + "\n" + "Kalan" + " " + checks[0].kalan;
                    }
                    Thread.Sleep(1000);
                    mainStackLayout.Clear();
                    this.Dispatcher.Dispatch(() =>
                    {

                        StackLayout horizontalStackLayout;
                        ImageButton imageButton;
                        StackLayout verticalStackLayout;
                        Label nameLabel;
                        Label alinmaTarihi;
                        Label vadeTarihi;
                        StackLayout verticalStackLayout2;
                        StackLayout verticalStackLayout3;
                        Label amountLabel;
                        Label amountLabel2;
                        int i = 0;
                        foreach (var dataItem in checks)
                        {
                            if (i == 0)
                            {
                                i = 1;
                                continue;
                            }
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
                                ImageButton_Clicked(sender, e, (int)dataItem.id);
                            };

                            horizontalStackLayout.Children.Add(imageButton);

                            verticalStackLayout = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.Center
                            };

                            nameLabel = new Label
                            {
                                Text = dataItem.kimdenAlindi,
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


                            verticalStackLayout3 = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.Start
                            };
                            amountLabel2 = new Label
                            {
                                Text = dataItem.cekSira,
                                HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                                Margin = new Thickness(0, 15, 0, 0),
                                LineBreakMode = LineBreakMode.WordWrap,
                                WidthRequest = 100,
                                FontSize = 10,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.White,
                                FontFamily = fontFamily

                            };
                            verticalStackLayout3.Children.Add(amountLabel2);

                            amountLabel2 = new Label
                            {
                                Text = String.IsNullOrEmpty(dataItem.kimeCiroEdildi) ? "" : dataItem.kimeCiroEdildi.Length > 13 ? dataItem.kimeCiroEdildi.Substring(0, 12) + "..." : dataItem.kimeCiroEdildi,
                                HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                                Margin = new Thickness(0, 5, 0, 0),
                                LineBreakMode = LineBreakMode.WordWrap,
                                WidthRequest = 80,
                                FontSize = 8,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.White,
                                FontFamily = fontFamily

                            };
                            verticalStackLayout3.Children.Add(amountLabel2);

                            horizontalStackLayout.Children.Add(verticalStackLayout3);
                            //horizontalStackLayout.Children.Add(amountLabel);

                            mainStackLayout.Children.Add(horizontalStackLayout);

                        }
                        running.IsVisible = false;
                    });
                    Thread.Sleep(500);
                    waitFilter = true;
            }

            catch (Exception ex)
            {
                running.IsVisible = false;
                waitFilter = false;
            }
        }

    }
    public async void kisiselCeklerOdemeler(object sender, EventArgs e)
    {
        var ay = Ay.SelectedItem;
        var yıl = Yıl.SelectedItem;
        //HelperClass.CloseKeyboard();
      
            if (waitFilter)
            {
                try
                {
                    running.IsVisible = true;
                    waitFilter = false;

                


                        string apiUrl = "xxxxxx" + ay + "&yil=" + yıl + "&key=" + textim.Text;
                        try
                        {
                            checks = await ApiServices.GetData<List<CheckDto>>(apiUrl);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

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
                if (checks.Count > 0)
                    {
                        toplamdurum.Text = "Ciro Edilen " + " " + checks[0].tutar + "\n" + "Kalan" + " " + checks[0].kalan;
                    }
                    // Thread.Sleep(1000);
                    mainStackLayout.Clear();
                    this.Dispatcher.Dispatch(() =>
                    {
                        ////   template oluşturup çağırabilirim ama şu an böyle kalsın sonra bakarım !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        ////   template oluşturup çağırabilirim ama şu an böyle kalsın sonra bakarım !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        ////   template oluşturup çağırabilirim ama şu an böyle kalsın sonra bakarım !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                        StackLayout horizontalStackLayout;
                        ImageButton imageButton;
                        StackLayout verticalStackLayout;
                        Label nameLabel;
                        Label alinmaTarihi;
                        Label vadeTarihi;
                        StackLayout verticalStackLayout2;
                        StackLayout verticalStackLayout3;
                        Label amountLabel;
                        Label amountLabel2;
                        int i = 0;
                        foreach (var dataItem in checks)
                        {
                            if (i == 0)
                            {
                                i = 1;
                                continue;
                            }
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
                                ImageButton_Clicked(sender, e, (int)dataItem.id);
                            };

                            horizontalStackLayout.Children.Add(imageButton);

                            verticalStackLayout = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.Center
                            };

                            nameLabel = new Label
                            {
                                Text = dataItem.kimdenAlindi,
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


                            verticalStackLayout3 = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.Start
                            };
                            amountLabel2 = new Label
                            {
                                Text = dataItem.cekSira,
                                HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                                Margin = new Thickness(0, 15, 0, 0),
                                LineBreakMode = LineBreakMode.WordWrap,
                                WidthRequest = 100,
                                FontSize = 10,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.White,
                                FontFamily = fontFamily

                            };
                            verticalStackLayout3.Children.Add(amountLabel2);

                            amountLabel2 = new Label
                            {
                                Text = String.IsNullOrEmpty(dataItem.kimeCiroEdildi) ? "" : dataItem.kimeCiroEdildi.Length > 13 ? dataItem.kimeCiroEdildi.Substring(0, 12) + "..." : dataItem.kimeCiroEdildi,
                                HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                                Margin = new Thickness(0, 5, 0, 0),
                                LineBreakMode = LineBreakMode.WordWrap,
                                WidthRequest = 80,
                                FontSize = 8,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.White,
                                FontFamily = fontFamily

                            };
                            verticalStackLayout3.Children.Add(amountLabel2);

                            horizontalStackLayout.Children.Add(verticalStackLayout3);
                            //horizontalStackLayout.Children.Add(amountLabel);

                            mainStackLayout.Children.Add(horizontalStackLayout);

                        }
                        running.IsVisible = false;

                    });
                    Thread.Sleep(500);
                    waitFilter = true;
                }

                catch (Exception ex)
                {
                    running.IsVisible = false;
                    waitFilter = true;
                }
            }
    }
    public async void textIzle(object sender, EventArgs e)
    {
 
            if (String.IsNullOrEmpty(textim.Text))
            {
              //  HelperClass.CloseKeyboard();
                try
                {
                    running.IsVisible = true;
                        string apiUrl = "xxxxx" + "Tumu" + "&yil=" + "0";
                        try
                        {
                            checks = await ApiServices.GetData<List<CheckDto>>(apiUrl);
                        }
                        catch (Exception ex)
                        {
                            running.IsVisible = false;
                            Console.WriteLine($"Error: {ex.Message}");
                        }

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
                if (checks.Count > 0)
                    {
                        toplamdurum.Text = "Ciro Edilen " + " " + checks[0].tutar + "\n" + "Kalan" + " " + checks[0].kalan;
                    }
                    //Thread.Sleep(1000);
                    mainStackLayout.Clear();
                    this.Dispatcher.Dispatch(() =>
                    {
                        StackLayout horizontalStackLayout;
                        ImageButton imageButton;
                        StackLayout verticalStackLayout;
                        Label nameLabel;
                        Label alinmaTarihi;
                        Label vadeTarihi;
                        StackLayout verticalStackLayout2;
                        StackLayout verticalStackLayout3;
                        Label amountLabel;
                        Label amountLabel2;
                        int i = 0;
                        foreach (var dataItem in checks)
                        {

                            if (i == 0)
                            {
                                i = 1;
                                continue;
                            }
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
                                ImageButton_Clicked(sender, e, (int)dataItem.id);
                            };

                            horizontalStackLayout.Children.Add(imageButton);

                            verticalStackLayout = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.Center
                            };

                            nameLabel = new Label
                            {
                                Text = dataItem.kimdenAlindi,
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

                            verticalStackLayout3 = new StackLayout
                            {
                                Orientation = StackOrientation.Vertical,
                                VerticalOptions = LayoutOptions.Start
                            };
                            amountLabel2 = new Label
                            {
                                Text = dataItem.cekSira,
                                HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                                Margin = new Thickness(0, 15, 0, 0),
                                LineBreakMode = LineBreakMode.WordWrap,
                                WidthRequest = 100,
                                FontSize = 10,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.White,
                                FontFamily = fontFamily

                            };
                            verticalStackLayout3.Children.Add(amountLabel2);

                            amountLabel2 = new Label
                            {
                                Text = String.IsNullOrEmpty(dataItem.kimeCiroEdildi) ? "" : dataItem.kimeCiroEdildi.Length > 13 ? dataItem.kimeCiroEdildi.Substring(0, 12) + "..." : dataItem.kimeCiroEdildi,
                                HorizontalOptions = LayoutOptions.Start,// Aligns label to the left
                                Margin = new Thickness(0, 5, 0, 0),
                                LineBreakMode = LineBreakMode.WordWrap,
                                WidthRequest = 80,
                                FontSize = 8,
                                FontAttributes = FontAttributes.Bold,
                                TextColor = Colors.White,
                                FontFamily = fontFamily

                            };
                            verticalStackLayout3.Children.Add(amountLabel2);

                            horizontalStackLayout.Children.Add(verticalStackLayout3);

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
       

    }


    public async void alinacakAra(object sender, EventArgs e)
    {
        //HelperClass.CloseKeyboard();

        return;

    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}