using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BarberiaAPI.Services
{
    public static class DataTableExtensions{
        public static List<Dictionary<string, object?>> ToDictionaryList(this DataTable dt){
            return dt.Rows
                .Cast<DataRow>()
                  .Select(row => dt.Columns
                          .Cast<DataColumn>()
                              .ToDictionary(
                                   col => col.ColumnName,
                                   col => row[col] == DBNull.Value ? null : row[col]))
                  .ToList();
        }
    }
}

