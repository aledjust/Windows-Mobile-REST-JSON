using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

namespace WmRestClients
{
    public class NewsResultsCache : IEnumerable<NewsResult>
    {
        #region Constructors

        public NewsResultsCache()
        {
            _NewsResults = new List<NewsResult>();
        }

        public NewsResultsCache(List<NewsResult> newsResults)
        {
            if (newsResults == null)
            {
                throw new NullReferenceException("NewsResults may not be null.");
            }
            _NewsResults = newsResults;
        }

        #endregion //Constructors

        #region Fields

        private List<NewsResult> _NewsResults;

        #endregion //Fields

        #region Methods

        private DataTable GetDataTableSchema()
        {
            DataTable result = new DataTable("results");
            typeof(NewsResult).GetProperties().ToList().ForEach(p => result.Columns.Add(p.Name));
            return result;
        }

        public DataTable GetDataTable()
        {
            DataTable result = GetDataTableSchema();
            List<PropertyInfo> properties = typeof(NewsResult).GetProperties().ToList();
            foreach (NewsResult r in this)
            {
                DataRow row = result.NewRow();
                foreach (PropertyInfo p in properties)
                {
                    object value = p.GetValue(r, null);
                    row[p.Name] = value;
                }
                result.Rows.Add(row);
            }
            return result;
        }

        public void Clear()
        {
            _NewsResults.Clear();
        }

        public void Add(NewsResult newsResult)
        {
            _NewsResults.Add(newsResult);
        }

        public IEnumerator<NewsResult> GetEnumerator()
        {
            return _NewsResults.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion //Methods
    }
}
