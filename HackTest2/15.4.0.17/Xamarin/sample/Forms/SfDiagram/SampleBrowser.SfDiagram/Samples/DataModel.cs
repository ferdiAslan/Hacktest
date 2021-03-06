#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class DataModel
    {
        //Initialize Employee Class
        internal ObservableCollection<DiagramEmployee> employee = new ObservableCollection<DiagramEmployee>();

        //Get Employee Details
        internal void Data()
        {
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
            {
                string path = "";
                if (Device.OS == TargetPlatform.iOS)
                    path = "Images/";
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2014",
                    Name = "Maria Anders",
                    Designation = "Managing Director",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "maria.andres@northwind.com",
                    HasChild = true,
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "84937",
                    DOJ = "18/10/2011",
                    Name = "Ana Trujillo",
                    Designation = "Project Manager",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "anatrujillo@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Maria Anders"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "03947",
                    DOJ = "18/10/2013",
                    Name = "Anto Moreno",
                    Designation = "Project Lead",
                    ImageUrl = path + "image57.png",
                    EmailId = "antomoreno@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Ana Trujillo"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "19287",
                    DOJ = "18/10/2011",
                    Name = "Clayton Hardy",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "image57.png",
                    EmailId = "Clayton.hardy@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Anto Moreno"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2015",
                    Name = "Christina kaff",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Image17.png",
                    EmailId = "christinakaff@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Georg Louis"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2012",
                    Name = "Hanna Moos",
                    Designation = "Team Manager",
                    ImageUrl = path + "image57.png",
                    EmailId = "hanna.moos@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Clayton Hardy"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2015",
                    Name = "Peter Citeaux",
                    Designation = "Team Manager",
                    ImageUrl = path + "Image17.png",
                    EmailId = "peterciteaux@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Anto Moreno"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2017",
                    Name = "Martín Kloss",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "Image17.png",
                    EmailId = "martin.kloss@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Carlos Schmitt"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2012",
                    Name = "Elizabeth Mary",
                    Designation = "Team Manager",
                    ImageUrl = path + "Image17.png",
                    EmailId = "elizabeth.mary@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Helen Marie"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2013",
                    Name = "Victoria Ash",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Image17.png",
                    EmailId = "victoria@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Ana Trujillo"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2016",
                    Name = "Francisco Yang",
                    Designation = "Project Trainee",
                    ImageUrl = path + "images9.png",
                    EmailId = "franscisco@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Martín Kloss"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2011",
                    Name = "Yang Wang",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "yangwang@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Peter Citeaux"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2010",
                    Name = "Lino Rodri",
                    Designation = "Project Manager",
                    ImageUrl = path + "Maria.png",
                    EmailId = "lino.rodri@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Maria Anders"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "18/10/2014",
                    Name = "Philip Cramer",
                    Designation = "Project Manager",
                    ImageUrl = path + "Image17.png",
                    EmailId = "philip.cramer@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Maria Anders"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "15/10/2015",
                    Name = "Pedro Afonso",
                    Designation = "Project Manager",
                    ImageUrl = path + "Paul.png",
                    EmailId = "pedro.afonso@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Hanna Moos"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "15/10/2011",
                    Name = "Elizabeth Roel",
                    Designation = "Project Lead",
                    ImageUrl = path + "Maria.png",
                    EmailId = "elizabeth.roel@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Philip Cramer"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "59305",
                    DOJ = "15/10/2013",
                    Name = "Janine Labrune",
                    Designation = "Project Trainee",
                    ImageUrl = path + "images9.png",
                    EmailId = "janine.labrune@northwind.com",
                    HasChild = false,
                    ReportingPerson = "John Rovelli"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "95836",
                    DOJ = "15/10/2012",
                    Name = "Ann Devon",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Image17.png",
                    EmailId = "ann.devon@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Howard Snyd"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "03993",
                    DOJ = "15/10/2012",
                    Name = "Roland Mendel",
                    Designation = "Team Manager",
                    ImageUrl = path + "image57.png",
                    EmailId = "rolandmendel@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Howard Snyd"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "01992",
                    DOJ = "15/10/2015",
                    Name = "Aria Cruz",
                    Designation = "Project Lead",
                    ImageUrl = path + "images2.png",
                    EmailId = "ariacruz@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Catherine Kaff"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "95837",
                    DOJ = "15/10/2016",
                    Name = "Martine Rancé",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "martinerance@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Diego Roel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "93711",
                    DOJ = "15/10/2015",
                    Name = "Maria Larsson",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "images2.png",
                    EmailId = "marialarsson@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Georg Louis"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "04992",
                    DOJ = "15/03/2015",
                    Name = "Diego Roel",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "images9.png",
                    EmailId = "diegoroel@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Catherine Kaff"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "83735",
                    DOJ = "15/03/2012",
                    Name = "Peter Franken",
                    Designation = "Project Trainee",
                    ImageUrl = path + "images9.png",
                    EmailId = "peter.franken@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Maria Larsson"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "81777",
                    DOJ = "01/03/2011",
                    Name = "Carine Schmitt",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "carineschmitt@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Diego Roel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "99994",
                    DOJ = "01/03/2016",
                    Name = "Paolo Accorti",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "paoloaccorti@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Diego Roel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "10101",
                    DOJ = "01/03/2015",
                    Name = "Eduardo Roel",
                    Designation = "Project Lead",
                    ImageUrl = path + "images9.png",
                    EmailId = "eduardoroel@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Ana Trujillo"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "98823",
                    DOJ = "01/03/2011",
                    Name = "José Pedro",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "jose.pedro@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Martín Kloss"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "20398",
                    DOJ = "01/03/2016",
                    Name = "Howard Snyd",
                    Designation = "Project Lead",
                    ImageUrl = path + "images2.png",
                    EmailId = "howardsnyd@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Peter Citeaux"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "77738",
                    DOJ = "01/03/2017",
                    Name = "Manu Pereira",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "images9.png",
                    EmailId = "manupereira@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Ana Trujillo"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "91292",
                    DOJ = "01/03/2010",
                    Name = "Mario Pontes",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Image17.png",
                    EmailId = "mario.pontes@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Roland Mendel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "65522",
                    DOJ = "01/03/2011",
                    Name = "Carlos Schmitt",
                    Designation = "Team Manager",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "carlosschmitt@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Roland Mendel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "99181",
                    DOJ = "01/03/2012",
                    Name = "Yoshi Latimer",
                    Designation = "Senior Manager",
                    ImageUrl = path + "eric.png",
                    EmailId = "yoshilatimer@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Nardo Batista"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "03993",
                    DOJ = "01/03/2011",
                    Name = "Patricia Kenna",
                    Designation = "Senior Manager",
                    ImageUrl = path + "Maria.png",
                    EmailId = "patriciakenna@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Liz Nixon"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "81918",
                    DOJ = "01/03/2017",
                    Name = "Helen Bennett",
                    Designation = "Senior Manager",
                    ImageUrl = path + "images2.png",
                    EmailId = "helenbennett@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Jose Pavarotti"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "06999",
                    DOJ = "17/03/2010",
                    Name = "Daniel Tonini",
                    Designation = "Project Lead",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "daniel.tonini@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Jaime Yorres"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "73779",
                    DOJ = "17/03/2010",
                    Name = "Annette Roel",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "images9.png",
                    EmailId = "annetteroel@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Philip Cramer"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "27222",
                    DOJ = "17/03/2013",
                    Name = "John Steel",
                    Designation = "Team Manager",
                    ImageUrl = path + "image57.png",
                    EmailId = "johnsteel@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Annette Roel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "36339",
                    DOJ = "17/08/2013",
                    Name = "Jaime Yorres",
                    Designation = "Team Manager",
                    ImageUrl = path + "Image17.png",
                    EmailId = "jaimeyorres@northwind.com",
                    HasChild = true,
                    ReportingPerson = "John Steel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "10295",
                    DOJ = "17/08/2013",
                    Name = "Carlos Nagy",
                    Designation = "Senior Manager",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "carlosnagy@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Annette Roel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "95826",
                    DOJ = "17/08/2012",
                    Name = "Felipe Kloss",
                    Designation = "Senior Manager",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "felipe.kloss@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Aria Cruz"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "28291",
                    DOJ = "17/08/2012",
                    Name = "Fran Wilson",
                    Designation = "Senior Manager",
                    ImageUrl = path + "image57.png",
                    EmailId = "fran.wilson@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Carlos Nagy"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "10395",
                    DOJ = "17/08/2012",
                    Name = "John Rovelli",
                    Designation = "Senior Manager",
                    ImageUrl = path + "images2.png",
                    EmailId = "johnrovelli@northwind.com",
                    HasChild = true,
                    ReportingPerson = "John Steel"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "00041",
                    DOJ = "17/08/2014",
                    Name = "Catherine Kaff",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "image57.png",
                    EmailId = "catherinekaff@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Yoshi Latimer"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "90906",
                    DOJ = "09/08/2014",
                    Name = "Jean Fresnière",
                    Designation = "Senior Manager",
                    ImageUrl = path + "Image17.png",
                    EmailId = "jean.freniere@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Yoshi Latimer"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "77282",
                    DOJ = "09/122014",
                    Name = "Simon Roel",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "simonroel@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Jean Fresnière"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "19098",
                    DOJ = "09/122014",
                    Name = "Yvonne Wong",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "yvonnewong@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Jean Fresnière"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "75638",
                    DOJ = "09/122016",
                    Name = "Rene Phillips",
                    Designation = "Project Trainee",
                    ImageUrl = path + "images2.png",
                    EmailId = "renephillips@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Martín Kloss"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "60021",
                    DOJ = "09/122016",
                    Name = "Yoshi Kenna",
                    Designation = "Senior Manager",
                    ImageUrl = path + "images9.png",
                    EmailId = "yoshikenna@northwind.com",
                    HasChild = true,
                    ReportingPerson = "José Pedro"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "50090",
                    DOJ = "09/122016",
                    Name = "Helen Marie",
                    Designation = "Senior Manager",
                    ImageUrl = path + "images2.png",
                    EmailId = "helenmarie@northwind.com",
                    HasChild = true,
                    ReportingPerson = "José Pedro"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "80091",
                    DOJ = "09/122012",
                    Name = "Georg Louis",
                    Designation = "Senior Manager",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "georg.louis@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Hanna Moos"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "78890",
                    DOJ = "09/122012",
                    Name = "Nardo Batista",
                    Designation = "Project Lead",
                    ImageUrl = path + "Maria.png",
                    EmailId = "nardobatista@northwind.com",
                    HasChild = true,
                    ReportingPerson = "José Pedro"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "62777",
                    DOJ = "09/122012",
                    Name = "Horst Kloss",
                    Designation = "Project Trainee",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "horstkloss@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Yoshi Kenna"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "01973",
                    DOJ = "28/122012",
                    Name = "Mauri Moroni",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "maurimoroni@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Elizabeth Mary"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "74891",
                    DOJ = "28/122012",
                    Name = "Jonas Bergsen",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "jonas.bergsen@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Elizabeth Mary"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "66201",
                    DOJ = "28/122012",
                    Name = "Jose Pavarotti",
                    Designation = "Senior Manager",
                    ImageUrl = path + "Maria.png",
                    EmailId = "jose.pavarotti@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Helen Marie"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "39846",
                    DOJ = "28/122015",
                    Name = "Miguel Angel",
                    Designation = "Project Trainee",
                    ImageUrl = path + "eric.png",
                    EmailId = "miguel.angel@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Aria Cruz"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "18276",
                    DOJ = "28/072015",
                    Name = "Jytte Petersen",
                    Designation = "Project Manager",
                    ImageUrl = path + "images9.png",
                    EmailId = "jyttepetersen@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Fran Wilson"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "30497",
                    DOJ = "28/072015",
                    Name = "Kloss Perrier",
                    Designation = "Project Lead",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "kloss.perrier@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Maria Larsson"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "91811",
                    DOJ = "28/072015",
                    Name = "Pascal Cartrain",
                    Designation = "Project Lead",
                    ImageUrl = path + "emp.png",
                    EmailId = "pascal.cartrain@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Carlos Nagy"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "77777",
                    DOJ = "28/072016",
                    Name = "Liz Nixon",
                    Designation = "Project Lead",
                    ImageUrl = path + "images2.png",
                    EmailId = "liznixon@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Fran Wilson"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "11786",
                    DOJ = "28/06/2016",
                    Name = "Liu Wong",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "image57.png",
                    EmailId = "liuwong@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Pascal Cartrain"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "55555",
                    DOJ = "18/072016",
                    Name = "Karin Josephs",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "images9.png",
                    EmailId = "karin.josephs@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Liz Nixon"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "11111",
                    DOJ = "18/072017",
                    Name = "Ruby Anabela",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "ruby.anabela@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Maria Larsson"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "93018",
                    DOJ = "18/072017",
                    Name = "Helvetis Nagy",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "helvetis.nagy@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Pascal Cartrain"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "83781",
                    DOJ = "18/072017",
                    Name = "Palle Ibsen",
                    Designation = "Project Trainee",
                    ImageUrl = path + "images2.png",
                    EmailId = "palleibsen@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Yoshi Latimer"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "84902",
                    DOJ = "18/05/2017",
                    Name = "Karl Jablonski",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "image57.png",
                    EmailId = "karljablonski@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Yoshi Kenna"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "83937",
                    DOJ = "18/03/2017",
                    Name = "Matti Kenna",
                    Designation = "Project Lead",
                    ImageUrl = path + "images2.png",
                    EmailId = "mattikenna@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Lúcia Carvalho"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "88729",
                    DOJ = "18/04/2015",
                    Name = "Zbyszek Yang",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "zbyszekyang@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Lúcia Carvalho"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "98765",
                    DOJ = "18/06/2015",
                    Name = "Nancy",
                    Designation = "Senior S/W Engg",
                    ImageUrl = path + "images9.png",
                    EmailId = "nancy@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Lúcia Carvalho"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "23456",
                    DOJ = "23/12/2015",
                    Name = "Georg Pipps",
                    Designation = "Project Trainee",
                    ImageUrl = path + "image57.png",
                    EmailId = "georg.pipps@northwind.com",
                    HasChild = false,
                    ReportingPerson = "Clayton Hardy"
                });
                employee.Add(new DiagramEmployee()
                {
                    ID = "09876",
                    DOJ = "23/12/2015",
                    Name = "Lúcia Carvalho",
                    Designation = "Project Lead",
                    ImageUrl = path + "Clayton.png",
                    EmailId = "lucia.carvalho@northwind.com",
                    HasChild = true,
                    ReportingPerson = "Karl Jablonski"
                });
                return;
            }
            else if (Device.OS == TargetPlatform.Windows)
            {
                employee.Add(new DiagramEmployee()
                {
                    Name = "Maria Anders",
                    ContactNo = 7899896099,
                    Designation = "Managing Director",
                    DOJ = "1-March-2010",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.eric.png",
                    Salary = 90000,
                    HasChild = true,
                });


                employee.Add(new DiagramEmployee()
                {
                    Name = "Pedro Afonso",
                    ContactNo = 7899896099,
                    Designation = "Project Manager",
                    DOJ = "1/May/2010",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Paul.png",
                    Salary = 80000,
                    ReportingPerson = "Elizabeth",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Elizabeth",
                    ContactNo = 7899896099,
                    Designation = "Project Lead",
                    DOJ = "27- Nov-2010",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Jenny.png",
                    Salary = 70000,
                    ReportingPerson = "George Lino",
                    HasChild = true,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Aria Cruz",
                    ContactNo = 7899896099,
                    Designation = "Project Lead",
                    DOJ = "12-feb-2010",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Jenny.png",
                    Salary = 70000,
                    ReportingPerson = "Philip Cramer",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Martin Sommer",
                    ContactNo = 7899896099,
                    Designation = "Senior S/W Engg",
                    DOJ = "23/may/2012",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.images3.png",
                    Salary = 60000,
                    ReportingPerson = "Philip Cramer",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Jaime Yorres",
                    ContactNo = 7899896099,
                    Designation = "Senior S/W Engg",
                    DOJ = "23/may/2012",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Clayton.png",
                    Salary = 50000,
                    ReportingPerson = "Carlos Nagy",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Hanna Moss",
                    ContactNo = 7899896099,
                    Designation = "Project Lead",
                    DOJ = "12-May-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Image9.png",
                    Salary = 70000,
                    ReportingPerson = "Daniel Tonini",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Howard Synder",
                    ContactNo = 7899896099,
                    Designation = "Project Lead",
                    DOJ = "18-dec-2010",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.images12.png",
                    Salary = 70000,
                    ReportingPerson = "George Lino",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Philip Cramer",
                    ContactNo = 7899896099,
                    Designation = "Project Manager",
                    DOJ = "07-August-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.images2.png",
                    Salary = 80000,
                    ReportingPerson = "Maria Anders",
                    HasChild = true,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Daniel Tonini",
                    ContactNo = 7899896099,
                    Designation = "Project Lead",
                    DOJ = "21-Sep-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.image57.png",
                    Salary = 70000,
                    ReportingPerson = "Maria Anders",
                    HasChild = true,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "George Lino",
                    ContactNo = 7899896099,
                    Designation = "Senior S/W Engg",
                    DOJ = "21-Sep-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Maria.png",
                    Salary = 60000,
                    ReportingPerson = "Maria Anders",
                    HasChild = true,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Yoshi Tannamuri",
                    ContactNo = 7899896099,
                    Designation = "Project Lead",
                    DOJ = "21-Sep-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.images3.png",
                    Salary = 50000,
                    ReportingPerson = "Daniel Tonini",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "John Steel",
                    ContactNo = 7899896099,
                    Designation = "Project Trainee",
                    DOJ = "21-Sep-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.images9.png",
                    Salary = 40000,
                    ReportingPerson = "Martin Sommer",
                    HasChild = false,
                });

                employee.Add(new DiagramEmployee()
                {
                    Name = "Carlos Nagy",
                    ContactNo = 7899891099,
                    Designation = "Project Trainee",
                    DOJ = "21-Sep-2011",
                    EmailId = "joplin@xyz.com",
                    ImageUrl = "SampleBrowser.SfDiagram.Image17.png",
                    Salary = 40000,
                    ReportingPerson = "Daniel Tonini",
                    HasChild = true,
                });
            }
        }
    }
}

/// <summary>
/// Employee class
/// </summary>
public class DiagramEmployee : INotifyPropertyChanged
{
    private string name;
    private double salary;
    private string destination;
    private string imageurl;
    private string doj;
    private string emailid;
    private double contactno;
    private string reportingPerson;
    private bool haschild;

    public DiagramEmployee()
    {

    }

    /// <summary>
    /// Get or set the haschild
    /// </summary>
    public bool HasChild
    {
        get { return haschild; }
        set
        {
            haschild = value;
        }
    }

    private string _mDesignation;
    private string id;

    /// <summary>
    /// Get or set the designation
    /// </summary>
    public string Designation
    {
        get { return _mDesignation; }
        set
        {
            if (_mDesignation != value)
            {
                _mDesignation = value;
                OnPropertyChanged("Designation");
            }
        }
    }

    /// <summary>
    /// Get or set the name
    /// </summary>
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(("Name"));
            }
        }
    }

    public string ID
    {
        get
        {
            return id;
        }
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(("ID"));
            }
        }
    }

    /// <summary>
    /// Get or set the reporting person
    /// </summary>
    public string ReportingPerson
    {
        get
        {
            return reportingPerson;
        }
        set
        {
            if (reportingPerson != value)
            {
                reportingPerson = value;
                OnPropertyChanged(("ReportingPerson"));
            }
        }
    }

    /// <summary>
    /// Get or set the reportingid
    /// </summary>
    public int ReportingId
    {
        get;
        set;
    }

    /// <summary>
    /// Get or set the salary
    /// </summary>
    public double Salary
    {
        get
        {
            return salary;
        }
        set
        {
            if (salary != value)
            {
                salary = value;
                OnPropertyChanged(("Salary"));
            }
        }
    }

    /// <summary>
    /// Get or set the destination
    /// </summary>
    public string Destination
    {
        get
        {
            return destination;
        }
        set
        {
            if (destination != value)
            {
                if (value != null)
                {
                    destination = value;
                    OnPropertyChanged(("Destination"));
                }
            }
        }
    }

    /// <summary>
    /// Get or set the imageurl
    /// </summary>
    public string ImageUrl
    {
        get
        {
            return imageurl;
        }
        set
        {
            if (imageurl != value)
            {
                if (value != null)
                {
                    imageurl = value;
                    OnPropertyChanged(("ImageUrl"));
                }
            }
        }
    }

    /// <summary>
    /// Get or set the DOJ
    /// </summary>
    public string DOJ
    {
        get
        {
            return doj;
        }
        set
        {
            if (doj != value)
            {
                doj = value;
                OnPropertyChanged(("Doj"));
            }
        }
    }

    /// <summary>
    /// Get or set the email id
    /// </summary>
    public string EmailId
    {
        get
        {
            return emailid;
        }
        set
        {
            if (emailid != value)
            {
                emailid = value;
                OnPropertyChanged(("EmailId"));
            }
        }
    }

    /// <summary>
    /// Get or set the ContactNo
    /// </summary>
    public double ContactNo
    {
        get
        {
            return contactno;
        }
        set
        {
            if (contactno != value)
            {
                contactno = value;
                OnPropertyChanged(("ContactNo"));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}