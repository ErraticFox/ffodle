using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ffodle
{
    public class BindableStringBuilder : INotifyPropertyChanged
    {
        private readonly StringBuilder _builder = new();

        private readonly EventHandler<EventArgs> TextChanged;

        public BindableStringBuilder(EventHandler<EventArgs> textChanged)
        {
            TextChanged = textChanged;
        }

        public string Text
        {
            get { return _builder.ToString(); }
        }

        public int Count
        {
            get { return _builder.Length; }
        }

        public void Append(string text)
        {
            _builder.Append(text);
            TextChanged?.Invoke(this, null);
            RaisePropertyChanged(() => Text);
        }

        public void AppendLine(string text)
        {
            _builder.AppendLine(text);
            TextChanged?.Invoke(this, null);
            RaisePropertyChanged(() => Text);
        }

        public void Clear()
        {
            _builder.Clear();
            TextChanged?.Invoke(this, null);
            RaisePropertyChanged(() => Text);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                return;
            }

            var handler = PropertyChanged;

            if (handler != null)
            {
                if (propertyExpression.Body is MemberExpression body)
                    handler(this, new PropertyChangedEventArgs(body.Member.Name));
            }
        }

        #endregion


    }
}
