        public void fillHumps(byte[] fred)
        {

            if ((fred[1] == 0x20) && (fred.Length == 20))
            {
                double Hum1 = (fred[2] * 256) + fred[3];
                double Temp1 = (fred[4] * 256) + fred[5];
                double Hum2 = (fred[6] * 256) + fred[7];
                double Temp2 = (fred[8] * 256) + fred[9];
                double Hum3 = (fred[10] * 256) + fred[11];
                double Temp3 = (fred[12] * 256) + fred[13];
                double Hum4 = (fred[14] * 256) + fred[15];
                double Temp4 = (fred[16] * 256) + fred[17];
                double TempC1 = procTempsC(Temp1); 
                double TempC2 = procTempsC(Temp2);  
                double TempC3 = procTempsC(Temp3);
                double TempC4 = procTempsC(Temp4);
                double RH1 = procHumsh(Hum1);
                double RH2 = procHumsh(Hum2);
                double RH3 = procHumsh(Hum3);
                double RH4 = procHumsh(Hum4);
                double RHt1 = (TempC1 - 25) * (t1 + (t2 * Hum1)) + RH1;
                double RHt2 = (TempC2 - 25) * (t1 + (t2 * Hum2)) + RH2;
                double RHt3 = (TempC3 - 25) * (t1 + (t2 * Hum3)) + RH3;
                double RHt4 = (TempC4 - 25) * (t1 + (t2 * Hum4)) + RH4;

                double Dew1 = 0;
                double Dew2 = 0;
                double Dew3 = 0;
                double Dew4 = 0;

                Dew1 = Math.Pow((RHt1 / 100), .125) * (112 + (.9 * TempC1)) + (.1 * TempC1) - 112;
                Dew2 = Math.Pow((RHt2 / 100), .125) * (112 + (.9 * TempC2)) + (.1 * TempC2) - 112;
                Dew3 = Math.Pow((RHt3 / 100), .125) * (112 + (.9 * TempC3)) + (.1 * TempC3) - 112;
                Dew4 = Math.Pow((RHt4 / 100), .125) * (112 + (.9 * TempC4)) + (.1 * TempC4) - 112;

                if (Hum1 == 0xf4f4) { textBox33.Text = "0.0"; } else { textBox33.Text = ((Dew1 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
                if (Hum2 == 0xf4f4) { textBox34.Text = "0.0"; } else { textBox34.Text = ((Dew2 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
                if (Hum3 == 0xf4f4) { textBox35.Text = "0.0"; } else { textBox35.Text = ((Dew3 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
                if (Hum4 == 0xf4f4) { textBox36.Text = "0.0"; } else { textBox36.Text = ((Dew4 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }

                if (Hum1 == 0xf4f4) { textBox18.Text = "0.0"; } else { textBox18.Text = RHt1.ToString("0.00") + "%RH"; }
                if (Temp1 == 0xf4f4) { textBox17.Text = "0.0"; } else { textBox17.Text = ((TempC1 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
                if (Hum2 == 0xf4f4) { textBox20.Text = "0.0"; } else { textBox20.Text = RHt2.ToString("0.00") + "%RH"; }
                if (Temp2 == 0xf4f4) { textBox19.Text = "0.0"; } else { textBox19.Text = ((TempC2 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
                if (Hum3 == 0xf4f4) { textBox22.Text = "0.0"; } else { textBox22.Text = RHt3.ToString("0.00") + "%RH"; }
                if (Temp3 == 0xf4f4) { textBox21.Text = "0.0"; } else { textBox21.Text = ((TempC3 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
                if (Hum4 == 0xf4f4) { textBox24.Text = "0.0"; } else { textBox24.Text = RHt4.ToString("0.00") + "%RH"; }
                if (Temp4 == 0xf4f4) { textBox23.Text = "0.0"; } else { textBox23.Text = ((TempC4 * 1.8) + 32).ToString("0.00") + "\u00b0F"; }
            }
        }