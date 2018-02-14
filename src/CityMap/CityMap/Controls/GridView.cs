//
// GridView.cs
//
// Copyright(c) 2016 Adam Pedley, 2018 Yauheni Pakala
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CityMap.Controls
{
    public class GridView : Grid
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(GridView), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(GridView), null);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(GridView), null);

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(GridView), null, BindingMode.OneWay,
                propertyChanged: async (bindable, oldValue, newValue) =>
                    await ((GridView)bindable).BuildTiles((IEnumerable<object>)newValue));

        private int _maxColumns = 2;
        private float _tileHeight = 100;

        public GridView()
        {
            for (var i = 0; i < MaxColumns; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public int MaxColumns
        {
            get { return _maxColumns; }
            set { _maxColumns = value; }
        }

        public float TileHeight
        {
            get { return _tileHeight; }
            set { _tileHeight = value; }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public async Task BuildTiles<T>(IEnumerable<T> tiles)
        {
            // Wipe out the previous row definitions if they're there.
            if (RowDefinitions.Any())
            {
                RowDefinitions.Clear();
            }
            var enumerable = tiles as IList<T> ?? tiles.ToList();
            var numberOfRows = Math.Ceiling(enumerable.Count / (float)MaxColumns);
            for (var i = 0; i < numberOfRows; i++)
            {
                RowDefinitions.Add(new RowDefinition { Height = TileHeight });
            }

            for (var index = 0; index < enumerable.Count; index++)
            {
                var column = index % MaxColumns;
                var row = (int)Math.Floor(index / (float)MaxColumns);

                var tile = await BuildTile(enumerable[index]);

                Children.Add(tile, column, row);
            }
        }

        private async Task<Layout> BuildTile(object itemModel)
        {
            return await Task.Run(() =>
            {
                var view = (Layout)ItemTemplate.CreateContent();
                var bindableObject = (BindableObject)view;

                var tapGestureRecognizer = new TapGestureRecognizer
                {
                    Command = Command,
                    CommandParameter = itemModel
                };
                view.GestureRecognizers.Add(tapGestureRecognizer);

                if (bindableObject != null)
                {
                    bindableObject.BindingContext = itemModel;
                }

                return view;
            });
        }
    }
}
