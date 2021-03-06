﻿namespace Msiler.HighlightSchemes
{
    public interface IListingHighlightingSchemeDef
    {
        string CommentHighlight { get; }
        string StringHighlight { get; }
        string OffsetHighlight { get; }
        string OpCodeHighlight { get; }
        string NumericHighlight { get; }
        string BuiltinTypeHighlight { get; }
        string ErrorHighlight { get; }
        string WarningHighlight { get; }
    }
}
