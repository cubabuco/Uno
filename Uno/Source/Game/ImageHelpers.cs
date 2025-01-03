namespace Uno
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    public class ImageHelpers : IDisposable
    {
        private bool _isDisposed;
        private readonly MemoryCacheWrapper<Assembly> _assemblyCache;

        public ImageHelpers()
        {
            _assemblyCache = new MemoryCacheWrapper<Assembly>("Assembly.Uno");
        }

        public Bitmap LoadEmbededImage(string embededFile)
        {
            Assembly assembly;

            if (_assemblyCache.ContainsKey("Uno"))
            {
                _assemblyCache.TryGetValue("Uno", out assembly);
            }
            else
            {
                assembly = Assembly.GetExecutingAssembly();
                _assemblyCache.AddOrUpdate("Uno", assembly);
            }

            var stream = assembly.GetManifestResourceStream(embededFile);

            if (stream == null)
            {
                MessageBox.Show("Unable to find resource " + embededFile,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                var img = new Bitmap(stream);
                return img;
            }

            return null;
        }

        ~ImageHelpers()
        {
            // Garbage collection has kicked in tidy up your object.
            Dispose(false);
        }

        // Implement IDisposable.
        public void Dispose()
        {
            // Dispose has been called clean up your object and members that
            // are disposable.
            Dispose(true);

            // Now Make sure that you don't call the cleanup again via the Finalizer
            // Effectively you are taking over garbage collection so make sure you
            // don't do it again
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            // Only do this once.
            if (!_isDisposed)
            {
                // If called via IDispose interface then clean up sub-objects.
                // That implement the IDispose interface.
                if (disposing)
                {
                    // Dispose managed resources.
                    _assemblyCache.Dispose();
                }

                // Now clean-up and objects that don't implement dispose.
                // i.e close any file handles 

                // Currently nothing to do.    
            }
            _isDisposed = true;
        }
    }
}