using StudentDorms.Domain.Config;
using StudentDorms.Models.Shared;
using StudentDorms.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace StudentDorms.Services.Interfaces
{
    public interface ISharedService
    {
        /// <summary>
        /// Метод кој ги враќа поставките за апликацијата
        /// </summary>
        /// <returns></returns>
        AppSettingsModel GetAppSettings();

        /// <summary>
        /// Метод кој ги враќа енумерација од опции Да, Не и Сите
        /// </summary>
        /// <returns>Листа од енумерација од опции Да, Не и Сите</returns>
        List<DropdownViewModel<int>> GetBooleanOptionsForDropdown();


        /// <summary>
        /// Метод кој ги претвара Id's во табела од int за да се прати на sql
        /// </summary>
        /// <returns>Листа од статуси за тој objectTypeId</returns>
        public DataTable CreateIntDataTable(DropdownViewModel<int>[] items);


        /// <summary>
        /// Метод кој враќа опции за групирањето на ентитетите
        /// </summary>
        /// <returns></returns>
        List<DropdownViewModel<int>> GetGroupingOptions();

    }
}
