﻿using System.Text.RegularExpressions;
using System.Windows.Controls;
using ICSharpCode.AvalonEdit;

namespace Msiler.UI
{
    public partial class MyControl : UserControl
    {
        private const string RepoUrl = @"https://github.com/segrived/Msiler";

        private readonly MyControlVM _viewModel;

        ToolTip toolTip = new ToolTip();
        Regex lineRegex =
            new Regex(@"^IL_(?<Offset>[a-f\d]+)\s+(?<Instruction>[a-z\d.]+)\s+(?<Operand>.*)$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);



        public MyControl() {
            InitializeComponent();
            this._viewModel = new MyControlVM();
            this.DataContext = this._viewModel;
            this.InstructionList.Options = new TextEditorOptions {
                EnableEmailHyperlinks = false,
                EnableHyperlinks = false
            };
        }


        private void InstructionList_MouseHover(object sender, System.Windows.Input.MouseEventArgs e) {
            var pos = InstructionList.GetPositionFromPoint(e.GetPosition(InstructionList));

            if (pos == null)
                return;

            int off = InstructionList.Document.GetOffset(pos.Value.Line, pos.Value.Column);
            var startOff = InstructionList.Document.GetLineByOffset(off).Offset;
            var endOff = InstructionList.Document.GetLineByOffset(off).EndOffset;
            var lineText = InstructionList.Document.GetText(startOff, endOff - startOff);

            var regMatch = lineRegex.Match(lineText);
            if (!regMatch.Success) {
                return;
            }

            string instruction = regMatch.Groups["Instruction"].Value.ToLower();

            var info = AssemblyParser.Helpers.GetInstructionInformation(instruction);
            if (info == null) {
                return;
            }

            toolTip.PlacementTarget = this;
            toolTip.Content = new TextEditor {
                Text = $"{info.Name}: {info.Description}",
                Opacity = 0.6,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden
            };
            toolTip.IsOpen = true;
            e.Handled = true;
        }

        private void InstructionList_MouseHoverStopped(object sender, System.Windows.Input.MouseEventArgs e) {
            toolTip.IsOpen = false;
        }

        private void HyperlinkOptions_Click(object sender, System.Windows.RoutedEventArgs e) {
            Common.Instance.Package.ShowOptionPage(typeof(ExtenstionOptions));
        }

        private void HyperlinkGithub_Click(object sender, System.Windows.RoutedEventArgs e) {
            System.Diagnostics.Process.Start(RepoUrl);
        }

        private void HyperlinkAbout_Click(object sender, System.Windows.RoutedEventArgs e) {
            var win = new AboutWindow();
            win.ShowDialog();
        }
    }
}