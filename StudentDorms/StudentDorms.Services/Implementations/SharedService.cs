using StudentDorms.AutoMapper;
using StudentDorms.Common.Exceptions;
using StudentDorms.Models.Enums;
using StudentDorms.Models.Shared;
using StudentDorms.Models.ViewModels;
using StudentDorms.Services.Interfaces;
using StudentDorms.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace StudentDorms.Services.Implementations
{
    public class SharedService : ISharedService
    {
        public SharedService(
        )
        {
        }

        public List<DropdownViewModel<int>> GetBooleanOptionsForDropdown()
        {
            var enumValues = Enum.GetValues(typeof(IsActiveEnum)).Cast<IsActiveEnum>();

            var dropdownItems = enumValues.Select(e => new DropdownViewModel<int>
            {
                Id = (int)e,
                Title = e.ToString()
            }).ToList();

            return dropdownItems;
        }

        public DataTable CreateIntDataTable(DropdownViewModel<int> [] items)
        {
            var dropdownViewModels = new DropdownViewModel<int>[0];
            items = items == null ? dropdownViewModels : items;
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));

            foreach (var i in items)
            {
                DataRow row = dt.NewRow();
                row["Id"] = i.Id;
                dt.Rows.Add(row);
            }
            return dt;
        }

        public AppSettingsModel GetAppSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings == null)
                throw new StudentDormsException("Не се пронајдени поставки за апликацијата");

            var appSettingsModel = appSettings.ToModel<AppSettingsModel, AppSettings>();
            return appSettingsModel;
        }

       


        public List<DropdownViewModel<int>> GetGroupingOptions()
        {
            var enumValues = Enum.GetValues(typeof(GroupingEnum)).Cast<GroupingEnum>();

            var dropdownItems = enumValues.Select(e => new DropdownViewModel<int>
            {
                Id = (int)e,
                Title = e.ToString()
            }).ToList();

            return dropdownItems;
        }


    }
}
