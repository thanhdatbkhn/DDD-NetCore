using System;
using System.Collections.Generic;
using iStorage.Data.DataContext;
namespace iStorage.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private iStorageContext _context;
        public UnitOfWork(iStorageContext context/*, string logFilePath*/)
        {
            _context = context;
            //_logFilePath = logFilePath;
        }

        #region Public member methods...
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var outputLines = new List<string>();
                //if (e is DbEntityValidationException)
                //{
                //    var validationException = e as DbEntityValidationException;
                //    foreach (var eve in validationException.EntityValidationErrors)
                //    {
                //        outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                //        }
                //    }
                //}
                //else
                //{
                //    outputLines.Add(string.Format("{0}: {1}", DateTime.Now, e.InnerException.InnerException.Message));
                //}

                //if (!string.IsNullOrWhiteSpace(_logFilePath))
                //{
                //    System.IO.File.AppendAllLines(_logFilePath, outputLines);
                //}

                throw e;
            }
        }
        #endregion
        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
