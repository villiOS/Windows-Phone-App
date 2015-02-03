using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Globalization;
using AForge.Neuro;
using AForge.Neuro.Learning;



namespace PanoramaApp2
{
    public partial class PivotPage10 : PhoneApplicationPage
    {





        private double[][] _inputData = null;
        private double[][] _outputData = null;
        ActivationNetwork network = null;
        int inputSayisi = 4;
        int gizliKatmanSayisi = 20;
        int cikisSayisi = 1;
        double alfa = 2.0;
        bool dongu = false;
        
        double[] _inputDataGelen1;
        double[] _inputDataGelen11;
        double[] _inputDataGelen111;
        double[] _inputDataGelen1111;
        double[] _inputDataGelen2;
        double[] _inputDataGelen22;
        double[] _inputDataGelen222;
        double[] _inputDataGelen2222;
        double[] _inputDataGelen3;
        double[] _inputDataGelen33;
        double[] _inputDataGelen333;
        
        double find = 0.0; 

        public PivotPage10()
        {
            InitializeComponent();
            #region EFFECTS SETTINGS
            NavigationInTransition navigateInTransition = new NavigationInTransition();

            navigateInTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeIn };
            navigateInTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeIn };

            NavigationOutTransition navigateOutTransition = new NavigationOutTransition();

            navigateOutTransition.Backward = new SlideTransition { Mode = SlideTransitionMode.SlideDownFadeOut };
            navigateOutTransition.Forward = new SlideTransition { Mode = SlideTransitionMode.SlideUpFadeOut };

            TransitionService.SetNavigationInTransition(this, navigateInTransition);
            TransitionService.SetNavigationOutTransition(this, navigateOutTransition);
            #endregion


            LoadTrainData();

            ReturnInputData();

            CreateNetwork();

            OutputCalculate();

            SendAdvice();

            


        }

        

        


        #region LOAD DATA
        private void LoadTrainData()
        {


            List<double[]> inputs = new List<double[]>();
            List<double[]> outputs = new List<double[]>();



            //var resource = Application.GetResourceStream(new Uri("iris_data.csv", UriKind.Relative));

            //StreamReader streamReader = new StreamReader(resource.Stream);

            //string x = streamReader.ReadToEnd();

            using (StreamReader okuyucu = File.OpenText("iris_data.csv"))
            {

                okuyucu.ReadLine();

                while (!okuyucu.EndOfStream)
                {
                    string satir = okuyucu.ReadLine();
                    string[] bolum = satir.Split(';');

                    double[] input = new double[4];
                    double[] output = new double[1];

                    //Get data
                    for (int i = 0; i < 4; i++)
                    {
                        input[i] = double.Parse(bolum[i + 1], NumberFormatInfo.InvariantInfo);

                        if (i == 0)
                        {


                            if (bolum[i].ToString() == "Iris-setosa")
                                output[i] = 1.0;

                            if (bolum[i].ToString() == "Iris-versicolor")
                                output[i] = 2.0;

                            if (bolum[i].ToString() == "Iris-virginica")
                                output[i] = 3.0;
                        }
                    }



                    outputs.Add(output);
                    inputs.Add(input);
                }
            }


            _inputData = inputs.ToArray();
            _outputData = outputs.ToArray();


            //daha sonra try-catch koyulacak
            MessageBox.Show("Iris Data Loaded");


        }
        #endregion

        #region RETURN INPUT DATA
        private void ReturnInputData()
        {
            // double cinsiyet = Convert.ToDouble(PhoneApplicationService.Current.State["cinsiyet"]);
            double cinsiyet =
                PhoneApplicationService.Current.State.ContainsKey("cinsiyet")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["cinsiyet"]) : 0.0;

            //  double burc = Convert.ToDouble(PhoneApplicationService.Current.State["burc"]);
            double burc =
                PhoneApplicationService.Current.State.ContainsKey("burc")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["burc"]) : 0.0;

            // double yas = Convert.ToDouble(PhoneApplicationService.Current.State["yas"]);
            double yas =
                PhoneApplicationService.Current.State.ContainsKey("yas")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["yas"]) : 0.0;

            //  double color = Convert.ToDouble(PhoneApplicationService.Current.State["color"]);
            double color =
                PhoneApplicationService.Current.State.ContainsKey("color")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["color"]) : 0.0;

            //  double kutlama = Convert.ToDouble(PhoneApplicationService.Current.State["kutlama"]);
            double kutlama =
                PhoneApplicationService.Current.State.ContainsKey("kutlama")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["kutlama"]) : 0.0;

            //double futbol = Convert.ToDouble(PhoneApplicationService.Current.State["futbol"]);

            double futbol =
                PhoneApplicationService.Current.State.ContainsKey("futbol")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["futbol"]) : 0.0;

            //double muzik = Convert.ToDouble(PhoneApplicationService.Current.State["muzik"]);

            double muzik =
                PhoneApplicationService.Current.State.ContainsKey("muzik")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["muzik"]) : 0.0;

            //double hobi = Convert.ToDouble(PhoneApplicationService.Current.State["hobi"]);


            double hobi =
                PhoneApplicationService.Current.State.ContainsKey("hobi")
                ?
                Convert.ToDouble(PhoneApplicationService.Current.State["hobi"]) : 0.0;

            //  double hayvan = Convert.ToDouble(PhoneApplicationService.Current.State["hayvan"]);
            double hayvan =
          PhoneApplicationService.Current.State.ContainsKey("hayvan")
          ?
          Convert.ToDouble(PhoneApplicationService.Current.State["hayvan"]) : 0.0;

            _inputDataGelen1 = new double[4] { 0.051, 0.035, 0.014, 0.002 }; //1
            _inputDataGelen11 = new double[4] { 0.049, 0.030, 0.014, 0.002 }; //1
            _inputDataGelen111 = new double[4] { 0.058, 0.040, 0.012, 0.002 }; //1
            _inputDataGelen1111 = new double[4] { 0.050, 0.034, 0.016, 0.004 }; //1
            _inputDataGelen2 = new double[4] { 0.070, 0.032, 0.047, 0.014 }; //2
            _inputDataGelen22 = new double[4] { 0.061, 0.028, 0.040, 0.013 }; //2
            _inputDataGelen222 = new double[4] { 0.051, 0.035, 0.014, 0.002 }; //2
            _inputDataGelen2222 = new double[4] { 0.058, 0.027, 0.039, 0.012 }; //2
            _inputDataGelen3 = new double[4] { 0.064, 0.027, 0.053, 0.019 }; //3
            _inputDataGelen33 = new double[4] { 0.077, 0.028, 0.067, 0.020 }; //3
            _inputDataGelen333 = new double[4] { 0.058, 0.027, 0.051, 0.019 }; //3
            //cinsiyet, burc, yas, color, kutlama, futbol, muzik, hobi, hayvan
            MessageBox.Show("" +
                cinsiyet + " " +
                burc + " " +
                yas + " " +
                color + " " +
                kutlama + " " +
                futbol + " " +
                muzik + " " +
                hobi + " " +
                hayvan + " "
                );
            
        }
        #endregion

        #region CREATE NETWORK
        private void CreateNetwork()
        {
            network = new ActivationNetwork(
                new BipolarSigmoidFunction(alfa),    //aktivasyon fonksiyonu
                inputSayisi,                                //input sayısı
                gizliKatmanSayisi,                               //gizli katman sayısı
                cikisSayisi                                 //çıkış katmanı sayısı
                );

            BackPropagationLearning backprob = new BackPropagationLearning(network);
            backprob.LearningRate = 0.1;
            backprob.Momentum = 0.0;

            int iterasyon = 1;

            while (!dongu)
            {
                double hata = backprob.RunEpoch(_inputData, _outputData);
                iterasyon++;

                if (iterasyon > 1000 )
                // || hata < 0.0008
                {
                    break;
                }
              
            }
            MessageBox.Show("Öneriler Hesaplandı");
        }
        #endregion

        #region OUTPUT CALCULATE
        private void OutputCalculate()
        {
            //for (int i = 0; i < 4; i++)
            //{
            //    _inputDataGelen[i] = _inputDataGelen[i] / 100;
            //}

            string onerilenHediye1 = network.Compute(_inputDataGelen1)[0].ToString();
            string onerilenHediye11 = network.Compute(_inputDataGelen11)[0].ToString();
            string onerilenHediye111 = network.Compute(_inputDataGelen111)[0].ToString();
            string onerilenHediye1111 = network.Compute(_inputDataGelen1111)[0].ToString();
            string onerilenHediye2 = network.Compute(_inputDataGelen2)[0].ToString();
            string onerilenHediye22 = network.Compute(_inputDataGelen22)[0].ToString();
            string onerilenHediye222 = network.Compute(_inputDataGelen222)[0].ToString();
            string onerilenHediye2222 = network.Compute(_inputDataGelen2222)[0].ToString();
            string onerilenHediye3 = network.Compute(_inputDataGelen3)[0].ToString();
            string onerilenHediye33 = network.Compute(_inputDataGelen33)[0].ToString();
            string onerilenHediye333 = network.Compute(_inputDataGelen333)[0].ToString();
            MessageBox.Show(
                onerilenHediye1 + " " + 
                onerilenHediye11 + " " +
                onerilenHediye111 + 
                onerilenHediye1111 + " " +
                onerilenHediye2 + " " +
                onerilenHediye22 + " " +
                onerilenHediye222 + " " +
                onerilenHediye2222 + " " +
                onerilenHediye3 + " " +
                onerilenHediye33 + " " +
                onerilenHediye333
                );

            find = network.Output[0];

            find = Math.Round(find,1); //tamsayı 

            

        }
        #endregion

        #region SEND ADVICE TO USER
        private void SendAdvice()
        {
            if (find >= 0.0 && find <= 1.7) //bu aralık optimize edilebilir
            {
                MessageBox.Show("Iris-setosa");
                //textBox7.Text = "1";
            }

            else if (find > 1.7 && find <= 2.6)
            {
                MessageBox.Show("Iris-versicolor");
                //textBox7.Text = "2";
            }

            else if (find > 2.6 && find <= 3.7)
            {
                MessageBox.Show("Iris-virginica"); 
                //textBox7.Text = "3";
            }

            else MessageBox.Show("Aralık Dışında");

        }
        #endregion

        private void img_tavsiye_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MessageBox.Show("Mouse Leave");
        }
    }
}