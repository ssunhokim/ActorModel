﻿using System;
using System.Windows.Input;

namespace TeamClient
{
    // 버튼 Command 바인딩 하기위한 클래스
    public class DelegateCommand : ICommand
    {
        private readonly Func<bool> canExecute;
        private readonly Action execute;

        public DelegateCommand(Action execute) : this(execute, null)
        {

        }
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            if (this.canExecute == null)
                return true;

            return this.canExecute();
        }
        public void Execute(object o)
        {
            this.execute();
        }
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
