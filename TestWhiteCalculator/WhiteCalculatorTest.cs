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
using System.Linq;
using System.Text;
using White.Core.Factory;
using White.Core.UIItems.Finders;
using White.Core.InputDevices;

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
        private static White.Core.Application _application;
        //Global variable to get the Main window of calculator from application.
        private static White.Core.UIItems.WindowItems.Window _mainWindow;
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
                 _mainWindow = _application.GetWindow(SearchCriteria.ByText("calc"), InitializeOption.NoCache);
                //Convert the open calculator into Date calculator using key board Hot Key(Ctrl+E)
                DateDifferenceCalculation();
               //Return back to Basic using Key Board Hot Key
                ReturnToBasicCalculatorUsingHotKey();
                //Return back to Basic using Menu Option
                ReturnToBasicCalculatorUsingMenu();
                //Open Help option in Calculator
                OpenHelpOptionInCalculator();
                //Perform Addition of few numbers
                PerformSummationOnCalculator();
                //Dispose the main window
                _mainWindow.Dispose();
                //Dispose the application
                _application.Dispose();
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        /// <summary>
        /// method to Perform Addition of two numbers and validate the result
        /// </summary>
        private static void PerformSummationOnCalculator()
        {
            //Button with Numerical value 1
            White.Core.UIItems.Button btn1 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("1"));
            //Button with Numerical value 2
            White.Core.UIItems.Button btn2 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("2"));
            //Button with Numerical value 3
            White.Core.UIItems.Button btn3 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("3"));
            //Button with Numerical value 4
            White.Core.UIItems.Button btn4 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("4"));
            //Button with Numerical value 5
            White.Core.UIItems.Button btn5 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("5"));
            //Button with Numerical value 6
            White.Core.UIItems.Button btn6 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("6"));
            //Button with Numerical value 7
            White.Core.UIItems.Button btn7 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("7"));
            //Button with Numerical value 8
            White.Core.UIItems.Button btn8 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("8"));
            //Button with Numerical value 9
            White.Core.UIItems.Button btn9 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("9"));
            //Button with Numerical value 0
            White.Core.UIItems.Button btn0 = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("0"));
            //Button with text as +(for sum)
            White.Core.UIItems.Button btnSum = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("Add"));
            //Read button to get the result
            White.Core.UIItems.Button btnResult = _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByText("Equals"));
            //add two numbers 1234 and 5678 and get the result.
            //Type First Numbers 1234
            btn1.Click();
            btn2.Click();
            btn3.Click();
            btn4.Click();
            //Press Add button
            btnSum.Click();
            //Type 2nd number 
            btn5.Click();
            btn6.Click();
            btn7.Click();
            btn8.Click();
            //Get the result
            btnResult.Click();
            //read the result
           White.Core.UIItems.Label resultLable= _mainWindow.Get<White.Core.UIItems.Label>(SearchCriteria.ByAutomationId("150"));
           string result = resultLable.Text;
            if (result=="6912")
            {
                Console.WriteLine("Addition of numbers is correct.the result is {0}",result);
            }
          //  Assert.AreEqual("6912", resultLable, "Sorry Summation is wrong!!");
        }
        /// <summary>
        /// Open help File from calculator menu
        /// </summary>
        private static void OpenHelpOptionInCalculator()
        {
            //Click on Help at Menu item
            var help = _mainWindow.Get<White.Core.UIItems.MenuItems.Menu>(SearchCriteria.ByText("Help"));
            help.Click();
            //Click on View Help guide to open new window from menu bar
            var viewHelp = _mainWindow.Get<White.Core.UIItems.MenuItems.Menu>(SearchCriteria.ByText("View Help"));
            viewHelp.Click();
        }
        /// <summary>
        /// Operate the Calculator in to basic mode through Menu option
        /// </summary>
        private static void ReturnToBasicCalculatorUsingMenu()
        {
            var menuView = _mainWindow.Get<White.Core.UIItems.MenuItems.Menu>(SearchCriteria.ByText("View"));
            menuView.Click();
            //select Basic
            var menuViewBasic = _mainWindow.Get<White.Core.UIItems.MenuItems.Menu>(SearchCriteria.ByText("Basic"));
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
            Keyboard.Instance.HoldKey(White.Core.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("E");
            Keyboard.Instance.LeaveKey(White.Core.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            //On Date window find the difference between dates.
            //Set value into combobox
            var comboBox = _mainWindow.Get<White.Core.UIItems.ListBoxItems.ComboBox>(SearchCriteria.ByAutomationId("4003"));
            comboBox.Select("Calculate the difference between two dates");
            //Click on Calculate button
            White.Core.UIItems.Button caclButton =
                _mainWindow.Get<White.Core.UIItems.Button>(SearchCriteria.ByAutomationId("4009"));
            caclButton.Click();
        }
    }
}
