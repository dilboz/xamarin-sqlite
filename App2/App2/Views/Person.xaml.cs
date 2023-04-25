using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Person : ContentPage
    {
        private List<Village> villages = new List<Village>();
        private List<Gender> genders = new List<Gender>();
        private List<Status> status = new List<Status>();
        private List<SocialStatus> socialStatus = new List<SocialStatus>();
        private List<Education> educations = new List<Education>();
        private List<DisabledLevel> disabledLevels = new List<DisabledLevel>();
        private List<Countrie> countries = new List<Countrie>();

        private string fullName;
        private string pasNumber;
        private string idVillages;
        private string idGenders;
        private string idStatus;
        private string idSocialStatus;
        private string idEducations;
        private int age;
        private bool isDisabled;
        private string idDisabledLevels;
        private bool isDualCitizenship;
        private bool isMigrationStatus;
        private string idCountry;
        
        public Person()
        {
            InitializeComponent();

            var forgetPasswordDisabled = new TapGestureRecognizer();
            forgetPasswordDisabled.Tapped += (s, e) =>
            {
                if (IsCheckedDisabled.IsChecked)
                {
                    IsCheckedDisabled.IsChecked = false;
                    DisabledLevelsText.IsEnabled = false;
                }
                else
                {
                    IsCheckedDisabled.IsChecked = true;
                    DisabledLevelsText.IsEnabled = true;
                }
            };
            LabelDisabled.GestureRecognizers.Add(forgetPasswordDisabled);

            var forgetPasswordDualCitizenship = new TapGestureRecognizer();
            forgetPasswordDualCitizenship.Tapped += (s, e) =>
            {
                if (DualCitizenship.IsChecked)
                {
                    DualCitizenship.IsChecked = false;
                }
                else
                {
                    DualCitizenship.IsChecked = true;
                }
            };
            LabelDualCitizenship.GestureRecognizers.Add(forgetPasswordDualCitizenship);

            var forgetPasswordMigrationStatus = new TapGestureRecognizer();
            forgetPasswordMigrationStatus.Tapped += (s, e) =>
            {
                if (MigrationStatus.IsChecked)
                {
                    MigrationStatus.IsChecked = false;
                    CountryText.IsEnabled = false;
                }
                else
                {
                    MigrationStatus.IsChecked = true;
                    CountryText.IsEnabled = true;
                }
            };
            LabelMigrationStatus.GestureRecognizers.Add(forgetPasswordMigrationStatus);

            villages = App._DatabaseHelper.GetVillage("SELECT Id, Name  FROM 'dbo.Villages' dv;");
            genders = App._DatabaseHelper.GetGenders("SELECT Id, Name  FROM 'dbo.Genders' dg;");
            status = App._DatabaseHelper.GetStatus("SELECT Id, Name  FROM 'dbo.Status' ds;");
            socialStatus = App._DatabaseHelper.GetStateTrigger("SELECT Id, Name  FROM 'dbo.SocialStatus' dss; ");
            educations = App._DatabaseHelper.GetEducationEducation("SELECT Id, Name  FROM 'dbo.Education' de; ");
            disabledLevels = App._DatabaseHelper.GetDisabledLevel("SELECT Id, Name  FROM 'dbo.DisabledLevels' ddl; ");
            countries = App._DatabaseHelper.GetCountries("SELECT Id, Name  FROM 'dbo.Countries' dc  ;");
        }

        private async void OnSelectVillage(object sender, EventArgs e)
        {
            var villageSelection = await DisplayActionSheet("Дехаро интихоб кунед", "Ба кафо", null,
                villages.Select(c => c.Name).ToArray());

            var selectedVillage = villages.FirstOrDefault(c => c.Name == villageSelection);

            if (selectedVillage != null)
            {
                VillageText.Text = selectedVillage.Name;
                idVillages = selectedVillage.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private async void OnSelectGender(object sender, EventArgs e)
        {
            var genderSelection = await DisplayActionSheet("Чинсро интихоб кунед", "Ба кафо", null,
                genders.Select(c => c.Name).ToArray());

            var selectedGender = genders.FirstOrDefault(c => c.Name == genderSelection);

            if (selectedGender != null)
            {
                GenderText.Text = selectedGender.Name;
                idGenders = selectedGender.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private async void OnSelectStatus(object sender, EventArgs e)
        {
            var statusSelection = await DisplayActionSheet("Вазъро интихоб кунед", "Ба кафо", null,
                status.Select(c => c.Name).ToArray());

            var selectedStatus = status.FirstOrDefault(c => c.Name == statusSelection);

            if (selectedStatus != null)
            {
                StatusText.Text = selectedStatus.Name;
                idStatus = selectedStatus.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private async void OnSelectSocialStatus(object sender, EventArgs e)
        {
            var socialStatusSelection = await DisplayActionSheet("Вазъи иҷтимоиро интихоб кунед", "Ба кафо", null,
                this.socialStatus.Select(c => c.Name).ToArray());

            var selectedSocialStatus = socialStatus.FirstOrDefault(c => c.Name == socialStatusSelection);

            if (selectedSocialStatus != null)
            {
                SocialStatusText.Text = selectedSocialStatus.Name;
                idSocialStatus = selectedSocialStatus.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private async void OnSelectEducation(object sender, EventArgs e)
        {
            var educationSelection = await DisplayActionSheet("Маълумотро интихоб кунед", "Ба кафо", null,
                this.educations.Select(c => c.Name).ToArray());

            var selectedEducation = educations.FirstOrDefault(c => c.Name == educationSelection);

            if (selectedEducation != null)
            {
                EducationText.Text = selectedEducation.Name;
                idEducations = selectedEducation.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private async void OnSelectDisabledLevel(object sender, EventArgs e)
        {
            var disabledLevelSelection = await DisplayActionSheet("Маълумотро интихоб кунед", "Ба кафо", null,
                this.disabledLevels.Select(c => c.Name).ToArray());

            var selectedDisabledLevel = disabledLevels.FirstOrDefault(c => c.Name == disabledLevelSelection);

            if (selectedDisabledLevel != null)
            {
                DisabledLevelsText.Text = selectedDisabledLevel.Name;
                idDisabledLevels = selectedDisabledLevel.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private async void OnSelectCountry(object sender, EventArgs e)
        {
            var countrySelection = await DisplayActionSheet("Маълумотро интихоб кунед", "Ба кафо", null,
                this.countries.Select(c => c.Name).ToArray());

            var selectedCountry = countries.FirstOrDefault(c => c.Name == countrySelection);

            if (selectedCountry != null)
            {
                CountryText.Text = selectedCountry.Name;
                idCountry = selectedCountry.Id;
            }

            ((Entry) sender).Unfocus();
        }

        private void OnCheckCheckedChangedIsDisabled(object sender, EventArgs e)
        {
            if (IsCheckedDisabled.IsChecked)
            {
                DisabledLevelsText.IsEnabled = true;
            }
            else
            {
                DisabledLevelsText.IsEnabled = false;
            }
        }

        private void OnCheckCheckedChangedMigrationStatus(object sender, EventArgs e)
        {
            if (MigrationStatus.IsChecked)
            {
                CountryText.IsEnabled = true;
            }
            else
            {
                CountryText.IsEnabled = false;
            }
        }

        private void CreatePerson(object sender, EventArgs e)
        {
            /*
            fullName = FullName.Text;
            pasNumber = PassNumber.Text;
            age = int.Parse(AgeText.Text);
            isDisabled = IsCheckedDisabled.IsChecked;
            isDualCitizenship = DualCitizenship.IsChecked;
            isMigrationStatus = MigrationStatus.IsChecked;

            string query = "INSERT INTO 'dbo.Persons' " +
                            "(id, " +
                           "FullName, " +
                           "Gender, " +
                           "StatusId, " +
                           "SocialStatusId, " +
                           "EducationId, " +
                           "InsertDate, " +
                           "UserId, " +
                           "VillageId, " +
                           "DistrictId, " +
                           "Age, " +
                           "IsDisabled, " +
                           "DisabledLevellId, " +
                           "PasNumber, " +
                           "DualCitizenship, " +
                           "MigrationStatus, " +
                           "CountryId, " +
                           "LiderName) " +
                           "VALUES " +
                           $"('', " +
                           $"'{fullName}', " +
                           $"'{idGenders}', " +
                           $"'{idStatus}', " +
                           $"'{idSocialStatus}', " +
                           $"'{idEducations}', " +
                           $"'{DateTime.Now.ToString("yyyy-MM-dd")}', " +
                           $"'{DataSettings.IDUser}', " +
                           $"'{idVillages}', " +
                           $"'{""}', " +
                           $"'{age}', " +
                           $"'{((bool) isDisabled == true ? "1" : "0")}', " +
                           $"'{idDisabledLevels}', " +
                           $"'{pasNumber}', " +
                           $"'{((bool) isDualCitizenship == true ? "1" : "0")}', " +
                           $"'{((bool) isMigrationStatus == true ? "1" : "0")}', " +
                           $"'{idCountry}', " +
                           $"'{""}' );";
                           */
            
           // var c = DatabaseHelper.InsertTest1();

           Test1 test1 = new Test1()
           {
               Name = "dilboz",
               Na = "safarov"
           };

           App._DatabaseHelper.SaveTest1(test1);

           // FullName.Text = c;

           /*DatabaseHelper.InsertPerson(new PersonModel()
           {
               Id = "", FullName = fullName, Gender = idGenders, StatusId = idStatus, SocialStatusId = idSocialStatus,
               EducationId = idEducations, InsertDate = DateTime.Now.ToString("yyyy-MM-dd"),  UserId = DataSettings.IDUser,
               VillageId = idVillages, DistrictId = "", Age = age.ToString(), IsDisabled = ((bool) isDisabled == true ? "1" : "0"),
               DisabledLevellId = idDisabledLevels, PasNumber = pasNumber, DualCitizenship = ((bool) isDualCitizenship == true ? "1" : "0"),
               MigrationStatus = ((bool) isMigrationStatus == true ? "1" : "0"),  CountryId = idCountry, LiderName = ""
           });*/
        }

        private void GetPersons(object sender, EventArgs e)
        {
            // string query = "SELECT * from 'dbo.Persons' dp;";
            PassNumber.Text = App._DatabaseHelper.GetTest1("Select * from test").Count.ToString();
        }
        
    }
}