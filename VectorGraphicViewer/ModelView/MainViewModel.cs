using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using VectorGraphicViewer.Model.Extensions;
using VectorGraphicViewer.Model.Repositories;
using Shape = VectorGraphicViewerShapesLib.Model.Shape;


namespace VectorGraphicViewer.ModelView
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region fields
        private double _width;
        private double _height;
        private double _canvasScaleX;
        private double _canvasScaleY;
        private string _dynamicResizeActive;
        private OpenFileDialog openFileDialog1;
        private JsonRepository _jsonRepository;
        #endregion
        #region Props
        public double Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged(nameof(Width));
                }
            }
        }
        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                }
            }
        }
        public double CanvasScaleX
        {
            get => _canvasScaleX;
            set
            {
                if (_canvasScaleX != value)
                {
                    _canvasScaleX = value;
                    OnPropertyChanged(nameof(CanvasScaleX));
                }
            }
        }
        public double CanvasScaleY
        {
            get => _canvasScaleY;
            set
            {
                if (_canvasScaleY != value)
                {
                    _canvasScaleY = value;
                    OnPropertyChanged(nameof(CanvasScaleY));
                }
            }
        }
        public string DynamicResizeActive
        {
            get => _dynamicResizeActive;
            set
            {
                if (_dynamicResizeActive != value)
                {
                    _dynamicResizeActive = value;
                    OnPropertyChanged(nameof(DynamicResizeActive));
                }
            }
        }
        public (double width, double height) BoundingBoxSize { get; set; }
        public bool DynamicResize { get; set; }
        public ObservableCollection<Shape> Shapes { get; set; }
        #endregion
        #region commands
        public ICommand SizeChangedCommand { get; private set; }
        public ICommand DynamicResizeCommand { get; private set; }
        public ICommand LoadFileCommand { get; private set; }
        #endregion
        #region notify
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public MainViewModel(JsonRepository jsonRepository)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            _jsonRepository = jsonRepository;
            Shapes = new ObservableCollection<Shape>();
            openFileDialog1 = new OpenFileDialog();

            Width = 1200;
            Height = 800;
            CanvasScaleX = 1;
            CanvasScaleY = 1;
            DynamicResizeActive = "#FF0000";
            DynamicResize = true;

            SizeChangedCommand = new RelayCommand<object>(OnSizeChanged);
            DynamicResizeCommand = new RelayCommand(SetDynamicResize);
            LoadFileCommand = new RelayCommand(LoadFile);

        }
        #endregion
        #region Command funcs
        private void LoadFile()
        {
            openFileDialog1.Filter = "Types (*.geojson;*.json)|*.json;*.geojson";
            openFileDialog1.ShowDialog();
            try
            {
                ReadData(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void OnSizeChanged(object? parameter)
        {
            if (parameter == null) return;

            if (DynamicResize)
            {
                Width = ((SizeChangedEventArgs)parameter).NewSize.Width;
                Height = ((SizeChangedEventArgs)parameter).NewSize.Height;
                UpdateScaleFactor(BoundingBoxSize);
            }
        }
        private void SetDynamicResize()
        {

            DynamicResize = !DynamicResize;

            if (DynamicResize)
            {
                DynamicResizeActive = "#FF0000";
            }
            else
            {
                DynamicResizeActive = "#00000000";
            }
        }
        #endregion
        #region helper
        public void ReadData(string filePath)
        {   // Read JSON from file

            Shapes.Clear();
            var shapes = _jsonRepository.GetShapes(filePath).ToList();

            BoundingBoxSize = shapes.SelectMany(x => x.GetBoundingCorners()).GetBoundingBoxSize();
            UpdateScaleFactor(BoundingBoxSize);
            foreach (var shape in shapes)
            {
                Shapes.Add(shape);
            }
        }
        public void UpdateScaleFactor((double width, double height) boundingBoxSize)
        {
            CanvasScaleX = (Width / boundingBoxSize.width) * 0.8;
            CanvasScaleY = (Height / boundingBoxSize.height) * 0.8;
        }
        #endregion
    }
}
