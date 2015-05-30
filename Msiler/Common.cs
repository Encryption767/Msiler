﻿using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Shell.Interop;

namespace Quart.Msiler
{
    public class Common
    {
        private static Common instance;
        public ObservableCollection<string> Messages = new ObservableCollection<string>();

        public static Common Instance
        {
            get
            {
                if (instance == null) {
                    instance = new Common();
                }
                return instance;
            }
        }

        public IVsSolutionBuildManager Build { get; set; }
        public IVsSolution Solution { get; set; }
        public IVsWindowFrame Frame { get; set; }
        public MsilerPackage Package { get; set; }
        public uint SolutionUpdateCookie { get; set; }
        public uint SolutionCookie { get; set; }
        private Common() { }
    }
}