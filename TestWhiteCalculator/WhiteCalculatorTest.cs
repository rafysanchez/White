// <copyright file="WhiteCalculatorTest.cs" >
//   Copyright @ Md. jawed. All rights reserved.
// </copyright>
// <summary>
//  Demo project to Automate Calculator using White Framework.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq
    ;
using System.Text;
using White.Core.Factory;
using White.Core.InputDevices;
using White.Core;
using White.Core.UIItems.WindowItems;
using static White.Core.WindowsAPI.KeyboardInput;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.ListBoxItems;
using White.Core.UIItems.MenuItems;

namespace TestWhiteCalculator
{
    /// <summary>
    /// Automate the Calculator basic funionality using White
    /// </summary>
    class WhiteCalculatorTest
    {
        // source exe file path. here it is calculator exe path
        private const string ExeSourceFile = @"C:\Windows\system32\calc.exe";
        //Global Variable to for Application launch
        private static Application _application;
        //Global variable to get the Main window of calculator from application.
        private static Window _mainWindow;
        /// <summary>
        /// Main method to automate calculator
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {

                //strat process for the above exe file location
                var psi = new ProcessStartInfo(ExeSourceFile);
                // launch the process through white application
                _application = White.Core.Application.AttachOrLaunch(psi);
                //Get the window of calculator from white application

                System.Threading.Thread.Sleep(3000);

                List<Window> windows = Desktop.Instance.Windows();

                System.Console.WriteLine("Pegando Calculadora");
                System.Threading.Thread.Sleep(1000);

                _mainWindow = windows.Find(x => x.Title.Contains("Calculadora"));

                //var obj = (Window)_mainWindow;
                //System.Threading.Thread.Sleep(1000);

                _mainWindow.Get<Button>(SearchCriteria.ByText("Dois")).Click();
                _mainWindow.Get<Button>(SearchCriteria.ByText("Dois")).Click();
                _mainWindow.Get<Button>(SearchCriteria.ByText("Mais")).Click();

                _mainWindow.Get<Button>(SearchCriteria.ByText("Três")).Click();
                _mainWindow.Get<Button>(SearchCriteria.ByText("Zero")).Click();
                _mainWindow.Get<Button>(SearchCriteria.ByText("Igual a")).Click();

                //obj.Focus();
                //Btn1Click();
                //System.Threading.Thread.Sleep(500);
                //Btn2Click();
                //System.Threading.Thread.Sleep(500);
                //BtnSumClick();
                //Btn3Click();
                //System.Threading.Thread.Sleep(500);
                //Btn4Click();
                //System.Threading.Thread.Sleep(500);
                //BtnEqualsClick();
                //System.Threading.Thread.Sleep(500);


                //Button btn1 = obj.Get<Button>(SearchCriteria.ByText("1"));
                //btn1.Click();






                ////_mainWindow = _application.GetWindow(SearchCriteria.ByText("Calculadora - Calculadora"), InitializeOption.NoCache);
                ////Convert the open calculator into Date calculator using key board Hot Key(Ctrl+E)
                //DateDifferenceCalculation();
                ////Return back to Basic using Key Board Hot Key
                //ReturnToBasicCalculatorUsingHotKey();
                ////Return back to Basic using Menu Option
                //ReturnToBasicCalculatorUsingMenu();
                ////Open Help option in Calculator
                //OpenHelpOptionInCalculator();
                ////Perform Addition of few numbers
                //PerformSummationOnCalculator();
                ////Dispose the main window
                //_mainWindow.Dispose();
                ////Dispose the application
                //_application.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_mainWindow != null) BtnCloseClick();
            }
            Console.ReadKey();
        }

        private static void BtnCloseClick()
        {
            _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("Close")).Click();
        }

        /// <summary>
        /// method to Perform Addition of two numbers and validate the result
        /// </summary>
        private static void PerformSummationOnCalculator()
        {
            //Button with Numerical value 1
            Button btn1 = Btn1Click();
            //Button with Numerical value 2
            Button btn2 = Btn2Click();
            //Button with Numerical value 3
            Button btn3 = Btn3Click();
            //Button with Numerical value 4
            Button btn4 = Btn4Click();

            //Button with Numerical value 5
            Button btn5 = _mainWindow.Get<Button>(SearchCriteria.ByText("5"));
            //Button with Numerical value 6
            Button btn6 = _mainWindow.Get<Button>(SearchCriteria.ByText("6"));
            //Button with Numerical value 7
            Button btn7 = _mainWindow.Get<Button>(SearchCriteria.ByText("7"));
            //Button with Numerical value 8
            Button btn8 = _mainWindow.Get<Button>(SearchCriteria.ByText("8"));
            //Button with Numerical value 9
            Button btn9 = _mainWindow.Get<Button>(SearchCriteria.ByText("9"));
            //Button with Numerical value 0
            Button btn0 = _mainWindow.Get<Button>(SearchCriteria.ByText("0"));
            //Button with text as +(for sum)
            BtnSumClick();
            //Read button to get the result
            BtnEqualsClick();
            //add two numbers 1234 and 5678 and get the result.
            //Type First Numbers 1234
            btn2.Click();
            btn3.Click();
            btn4.Click();
            //Press Add button
            //Type 2nd number 
            btn5.Click();
            btn6.Click();
            btn7.Click();
            btn8.Click();
            //Get the result
            //read the result
            Label resultLable = _mainWindow.Get<Label>(SearchCriteria.ByAutomationId("150"));
            string result = resultLable.Text;
            if (result == "6912")
            {
                Console.WriteLine("Addition of numbers is correct.the result is {0}", result);
            }
            //  Assert.AreEqual("6912", resultLable, "Sorry Summation is wrong!!");
        }

        private static void BtnEqualsClick()
        {
            Button btnEqual = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("Equals"));
            btnEqual.Click();
        }

        private static void BtnSumClick()
        {
            Button btnSum = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("Add"));
            btnSum.Click();
        }

        private static Button Btn4Click()
        {
            Button btn4 = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("num4Button"));
            btn4.Click();
            return btn4;
        }

        private static Button Btn3Click()
        {
            Button btn3 = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("num3Button"));
            btn3.Click();
            return btn3;
        }

        private static Button Btn2Click()
        {
            Button btn2 = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("num2Button"));
            btn2.Click();
            return btn2;
        }

        private static Button Btn1Click()
        {
            Button btn1 = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("num1Button"));
            btn1.Click();
            return btn1;
        }

        /// <summary>
        /// Open help File from calculator menu
        /// </summary>
        private static void OpenHelpOptionInCalculator()
        {
            //Click on Help at Menu item
            var help = _mainWindow.Get<Menu>(SearchCriteria.ByText("Help"));
            help.Click();
            //Click on View Help guide to open new window from menu bar
            var viewHelp = _mainWindow.Get<Menu>(SearchCriteria.ByText("View Help"));
            viewHelp.Click();
        }
        /// <summary>
        /// Operate the Calculator in to basic mode through Menu option
        /// </summary>
        private static void ReturnToBasicCalculatorUsingMenu()
        {
            var menuView = _mainWindow.Get<Menu>(SearchCriteria.ByText("View"));
            menuView.Click();
            //select Basic
            var menuViewBasic = _mainWindow.Get<Menu>(SearchCriteria.ByText("Basic"));
            menuViewBasic.Click();

        }
        /// <summary>
        /// Change the calculator mode in basic using Key Board Hot Key
        /// </summary>
        private static void ReturnToBasicCalculatorUsingHotKey()
        {

            Keyboard.Instance.HoldKey(White.Core.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.PressSpecialKey(White.Core.WindowsAPI.KeyboardInput.SpecialKeys.F4);
            Keyboard.Instance.LeaveKey(White.Core.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
        }
        /// <summary>
        /// Find difference between dates through calculator
        /// </summary>
        private static void DateDifferenceCalculation()
        {
            _mainWindow.Keyboard.HoldKey(SpecialKeys.CONTROL);
            _mainWindow.Enter("E");
            _mainWindow.Keyboard.LeaveKey(SpecialKeys.CONTROL);

            //On Date window find the difference between dates.
            //Set value into combobox
            var comboBox = _mainWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("4003"));
            comboBox.Select("Calculate the difference between two dates");
            //Click on Calculate button
            Button caclButton = _mainWindow.Get<Button>(SearchCriteria.ByAutomationId("4009"));
            caclButton.Click();
        }
    }
}
