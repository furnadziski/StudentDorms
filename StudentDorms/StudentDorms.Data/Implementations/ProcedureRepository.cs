using StudentDorms.Data.Context;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static StudentDorms.Data.Interfaces.IProcedureRepository;

namespace StudentDorms.Data.Implementations
{
    public class ProcedureRepository<TEntity> : IProcedureRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext DbContext;

        public ProcedureRepository(DatabaseContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<TEntity> ExecListResultQuery(string queryName, object[] parameters)
        {
            if (parameters != null)
            {
                string completeProcCall = string.Format("Exec {0}", queryName);
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter.Direction == System.Data.ParameterDirection.Output)
                    {
                        completeProcCall += " " + parameter.ParameterName + " OUTPUT,";
                    }
                    else if (parameter.SqlDbType == System.Data.SqlDbType.Structured)
                    {
                        parameter.TypeName = GetTableValueParam(parameter.ParameterName);
                        completeProcCall += " " + parameter.ParameterName + ",";
                    }
                    else
                    {
                        completeProcCall += " " + parameter.ParameterName + ",";
                    }

                }
                completeProcCall = completeProcCall.TrimEnd(',');
                var result = DbContext.Set<TEntity>().FromSqlRaw(completeProcCall, parameters).ToList();
                return result;
            }
            else
                return DbContext.Set<TEntity>().FromSqlRaw(string.Format("Exec {0}", queryName)).ToList();
        }

        public TEntity ExecSingleResultQuery(string queryName, object[] parameters)
        {
            if (parameters != null)
            {
                string completeProcCall = string.Format("Exec {0}", queryName);
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter.Direction == System.Data.ParameterDirection.Output)
                    {
                        completeProcCall += " " + parameter.ParameterName + " OUTPUT,";
                    }
                    else if (parameter.SqlDbType == System.Data.SqlDbType.Structured)
                    {
                        parameter.TypeName = GetTableValueParam(parameter.ParameterName);
                        completeProcCall += " " + parameter.ParameterName + ",";
                    }
                    else
                    {
                        completeProcCall += " " + parameter.ParameterName + ",";
                    }

                }
                completeProcCall = completeProcCall.TrimEnd(',');
                return DbContext.Set<TEntity>().FromSqlRaw(completeProcCall, parameters).ToList().FirstOrDefault();
            }
            else
                return DbContext.Set<TEntity>().FromSqlRaw(string.Format("Exec {0}", queryName)).ToList().FirstOrDefault();
        }


        public void ExecuteSqlCommand(string queryName, object[] parameters)
        {
            if (parameters != null)
            {
                string completeProcCall = string.Format("Exec {0}", queryName);
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter.Direction == System.Data.ParameterDirection.Output)
                    {
                        completeProcCall += " " + parameter.ParameterName + " OUTPUT,";
                    }
                    else if (parameter.SqlDbType == System.Data.SqlDbType.Structured)
                    {
                        parameter.TypeName = GetTableValueParam(parameter.ParameterName);
                        completeProcCall += " " + parameter.ParameterName + ",";
                    }
                    else
                    {
                        completeProcCall += " " + parameter.ParameterName + ",";
                    }

                }
                completeProcCall = completeProcCall.TrimEnd(',');
                DbContext.Database.ExecuteSqlRaw(completeProcCall, parameters);
            }
            else
                DbContext.Database.ExecuteSqlRaw(string.Format("Exec {0}", queryName));
        }


        private static string GetTableValueParam(string paramName)
        {
            var tableValueParam = "";
            switch (paramName)
            {
                case "@StateDefinitionId":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@UserId":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@AbsenceTypeId":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@ListOfRoles":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@ListOfDepartment":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@ListOfEmployee":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@ListOfMeals":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@ListOfDocumentTypes":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@SurveyCategories":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@StateDefinitions":
                    tableValueParam = "dbo.IntTable";
                    break;
                case "@CollectionOfUsers":
                    tableValueParam = "dbo.IntTable";
                    break;
            }
            return tableValueParam;
        }
    }
}
