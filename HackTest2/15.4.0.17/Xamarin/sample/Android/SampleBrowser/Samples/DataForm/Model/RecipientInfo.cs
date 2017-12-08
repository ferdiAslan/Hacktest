#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace SampleBrowser
{
    public enum AccountType
    {
        Savings,
        Current,
        Overdraft,
        CashCredit,
        LoanAccount,
        NRE,
        CardPayment
    }

    class RecipientInfo : INotifyPropertyChanged, IDataErrorInfo
    {

        #region Fields       

        private string accountNumber;
        private string accountNumber1;

        private string email;
        private double amount;
        private string name;
        private string swift;
        private AccountType accountType;
        Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        #endregion

        #region Constructor

        public RecipientInfo()
        {

        }

        #endregion

        #region Public Properties  

        [Display(ShortName = "Account No.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the account number.")]
        public string AccountNumber
        {
            get { return this.accountNumber; }
            set
            {
                if (value != AccountNumber)
                {
                    this.accountNumber = value;
                    RaisePropertyChanged("AccountNumber");
                }
            }
        }

        [Display(ShortName = "Re-enter the Account No.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please re-enter the account number.")]
        public string AccountNumber1
        {
            get { return this.accountNumber1; }
            set
            {
                if (value != AccountNumber1)
                {
                    this.accountNumber1 = value;
                    RaisePropertyChanged("AccountNumber1");
                }
            }
        }

        [Display(ShortName = "Account Type")]
        public AccountType AccountType
        {
            get { return accountType; }
            set
            {
                accountType = value;
                RaisePropertyChanged("AccountType");
            }
        }

        [Display(Order = 0, ShortName = "SWIFT Code", Prompt = "Enter 8 or 11 upper case letters")]
        [RegularExpression("^[A-Z]{6}[A-Z0-9]{2}([A-Z0-9]{3})?$",
         ErrorMessage = "SWIFT code should be 8 or 11 upper case letters.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the SWIFT code.")]
        public string SWIFT
        {
            get { return this.swift; }
            set
            {
                this.swift = value;
                RaisePropertyChanged("SWIFT");
            }
        }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name.")]
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                RaisePropertyChanged("Name");
            }
        }

        [Display(ShortName = "Email ID")]
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        [Display(ShortName = "Transfer amount")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the amount.")]
        public double Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                RaisePropertyChanged("Amount");
            }
        }
        #endregion

        #region INotifyPropertyChanged implementation
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        [Display(AutoGenerateField = false)]
        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "AccountNumber" && !string.IsNullOrEmpty(AccountNumber))
                {
                    var accountNumberLength = AccountNumber.ToString().Length;
                    if (accountNumberLength > 10 || accountNumberLength < 5)
                        return "Account number length should be between 5 to 10. ";
                }
                else if (columnName == "AccountNumber1" && !string.IsNullOrEmpty(AccountNumber1))
                {
                    var accountNumberLength = AccountNumber1.ToString().Length;
                    if (AccountNumber1 != AccountNumber)
                        return "Account numbers do not match.";
                    else if (accountNumberLength > 10 || accountNumberLength < 5)
                        return "Account number length should be between 5 to 10. ";
                }
                else if (columnName == "Amount")
                {
                    if (Amount <= 0)
                        return "Amount should be more than zero.";
                }
                else if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                        return string.Empty;
                    return !(emailRegex.IsMatch(Email)) ? "Email ID not in correct format." : null;
                }
                return string.Empty;
            }
        }
    }
}