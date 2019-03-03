using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOPB.DAL.TableAdapter.Glossary
{
    class TypeStreetTableAdapter : BaseTableAdapter
    {
        /// <summary>
        /// _commandCollection[0] = [R]
        /// </summary>
        protected override void InitCollection()
        {
            this._commandCollection = new SqlCommand[1];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = $"SELECT   [TypeStreetID] \n"
                                                     + "      ,[Name] \n"
                                                     + "      ,[SocrName] \n"
                                                     + "  FROM [dbo].[vGetTypeStreet]";
            this._commandCollection[0].CommandType = CommandType.Text;
        }

        public override int Fill(DataTable dataTable)
        {
            this.Adapter.SelectCommand = this._commandCollection[0];
            if (ClearBefore)
            {
                dataTable.Clear();
            }

            return this.Adapter.Fill(dataTable);
        }
    }
}
