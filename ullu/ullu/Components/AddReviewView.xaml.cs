﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ullu.Components
{
    public partial class AddReviewView : ContentView
    {
        public AddReviewView()
        {
            InitializeComponent();
            starOne.IsStarred = true;
        }
    }
}
