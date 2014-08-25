using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace BinaryClockTry1
{
    //enum ThreeStates : byte
    //{
    //    OFF = 0,
    //    ON = 1,
    //    DISABLED = 2,
    //}

    public class DigitToBinaryConverter : IValueConverter
    {
        byte[,] digitsX = new byte[10, 4] {
            {
                0,0,0,0 //0
            },
            {
                1, 0, 0, 0, //1
            },
            {
                0, 1, 0, 0,  //2
            },
            {
                1, 1, 0, 0, //3
            },
            {
                0, 0, 1, 0, //4
            },
            {
                1, 0, 1, 0, //5
            },
            {
                0, 1, 1, 0, //6
            },
            {
                1, 1, 1, 0, //7
            },
            {
                0, 0, 0, 1, //8
            },
            {
                1, 0, 0, 1 //9
            },
            //{
            //    0, 2, 2, 1, //8
            //},
            //{
            //    1, 2, 2, 1 //9
            //},
        };

        //bool[,] digitsN = new bool[10, 4] {
        //    {
        //        false,false,false,false //0
        //    },
        //    {
        //        true, false, false, false, //1
        //    },
        //    {
        //        false, true, false, false,  //2
        //    },
        //    {
        //        true, true, false, false, //3
        //    },
        //    {
        //        false, false, true, false, //4
        //    },
        //    {
        //        true, false, true, false, //5
        //    },
        //    {
        //        false, true, true, false, //6
        //    },
        //    {
        //        true, true, true, false, //7
        //    },
        //    {
        //        false, false, false, true, //8
        //    },
        //    {
        //        true, false, false, true //9
        //    },
        //};

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int digit = -1;
            int segment = -100;
            int max = -1;

            if (value.GetType() == typeof(int))
            {
                String[] parameters = ((String)parameter).Split(';');
                digit = (int)value;
                segment = int.Parse(parameters[0]);
                max = int.Parse(parameters[1]);
                //segment = int.Parse((String)parameter);
            }

            byte makeVisible = 0;

            if (segment >= 0)
            {
                if (targetType == typeof(Visibility))
                {
                    if (digit != -1)
                    {
                        makeVisible = (digitsX[digit, segment-1]);
                    }
                    else if (value.GetType() == typeof(Visibility))
                    {
                        return (Visibility)value;
                    }

                    if (makeVisible == 1)
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                }
                else if (targetType == typeof(String))
                {
                    return digit.ToString();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                if (targetType == typeof(Visibility))
                {
                    if (digit != -1)
                    {
                        //negate segment
                        makeVisible = (digitsX[digit, -segment - 1]);
                    }
                    else if (value.GetType() == typeof(Visibility))
                    {
                        return (Visibility)value;
                    }

                    if (
                        //makeVisible == 2 ||
                        makeVisible == 0 &&(
                        (
                        max == 9 && 
                        (
                            ((-segment - 1) == 1) ||
                            (-segment - 1) == 2)
                        ) && digit > 7
                        ||
                        (max == 6 && (-segment - 1) == 1) && digit > 3 ||
                        (max == 2 && (-segment - 1) == 0 && digit > 1) ||
                        (max == 4 && (-segment - 1) == 0 && digit == 2)
                        )
                        )
                    {
                        return Visibility.Visible;
                    }
                    else
                    {
                        return Visibility.Collapsed;
                    }
                }
                else if (targetType == typeof(String))
                {
                    return digit.ToString();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }


        }



        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}


