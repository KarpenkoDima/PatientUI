﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOPB.DAL.ARCH.TableAdapter.Glossary
{
    class GenderTableAdapter : BaseTableAdapter
    {
        protected override void InitCollection()
        {
            this._commandCollection = new SqlCommand[1];
            this._commandCollection[0] = new SqlCommand();
            this._commandCollection[0].Connection = this.Connection;
            this._commandCollection[0].CommandText = $"SELECT [GenderID] \n"
                                                     + "      ,[Name] \n"
                                                     + "  FROM [dbo].[vGetGender]";
            this._commandCollection[0].CommandType = CommandType.Text;
        }

        public override int Fill(DataTable table)
        {
            this.Adapter.SelectCommand = _commandCollection[0];
            try
            {
                if (ClearBefore)
                {
                    table.Clear();
                }
            }
            catch (InvalidConstraintException)
            {
                throw;
            }
            return this.Adapter.Fill(table);
        }
    }
}
