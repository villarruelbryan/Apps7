using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Apps7
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();//Implementado en cada proyecto Android o IOS
    }
}
