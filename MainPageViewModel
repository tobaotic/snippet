using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Navigation;
using SQLite;
using ExistingSQLite.Model;

namespace ExistingSQLite.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public String MoveSQLiteMessage { get; set; }

        private ObservableCollection<Model.People> _peoples;
        public ObservableCollection<Model.People> Peoples
        {
            get => _peoples;
            set => SetProperty(ref _peoples, value);
        }

        public DelegateCommand GetPeoplesData { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            GetPeoplesData = new DelegateCommand(GetPeoplesDataFromTable);

            BLL.ResourceHelper ResHelper = new BLL.ResourceHelper();

            //Move from resoures to file sytsem
            if (ResHelper.MoveToSharedFolder())
            {
                MoveSQLiteMessage = " > SQLite moved to the new working location.";
            };
        }

        private void GetPeoplesDataFromTable()
        {
            string pathTo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "peoples.sqlite");

            if (File.Exists(pathTo))
            {
                SQLiteConnection sqlConn = new SQLiteConnection(pathTo);

                List<Model.People> peoples = sqlConn.Table<People>().ToList();

                Peoples = new ObservableCollection<Model.People>(peoples);
            }
        }
    }
}
