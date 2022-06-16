using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using Baumax.Contract.QueryResult;
using Baumax.Contract.TimePlanning;

namespace Baumax.ClientUI.FormEntities.TimePlanning
{
    class Painters
    {
        public static Color EMPTY_COLOR = Color.White;
        public static Color FOCUSED_COLOR = Color.LightBlue ;
        public static Color ADDITIONAL_CHARGES_COLOR = Color.Yellow ;
        public static Color FEAST_COLOR = Color.LightGreen;
        public static Color CLOSEDDAY_COLOR = Color.LightGray;
        public static Color DISABLE_COLOR = Color.Gray;


        public static  Font _cellFont = new Font("Verdana", 8F);

        public static void DrawFixedCells(RowCellCustomDrawEventArgs e, string employeefullname, bool isfocused)
        {
            HeaderObjectInfoArgs args = new HeaderObjectInfoArgs();
            args.BackAppearance = e.Appearance;
            args.Bounds = Rectangle.Inflate(e.Bounds, 2, 2);
            args.Cache = e.Cache;
            args.Caption = null;
            args.State = (isfocused) ? ObjectState.Hot : ObjectState.Normal;
            //args.SetAppearance( e.Appearance);
            
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Painter.Header.DrawObject(args);

            e.Appearance.DrawString(e.Cache, 
                                    e.CellValue.ToString (),//employeefullname, 
                                    Rectangle.Inflate(e.Bounds, -2, -2), 
                                    e.Cache.GetSolidBrush(e.Appearance.ForeColor),
                                    e.Appearance.GetStringFormat(TextOptions.DefaultOptionsMultiLine)); 

            
        }
        public static void DrawFixedCells_2(RowCellCustomDrawEventArgs e, string employeefullname, bool isfocused, bool usedText)
        {
            HeaderObjectInfoArgs args = new HeaderObjectInfoArgs();
            args.BackAppearance = e.Appearance;
            args.Bounds = Rectangle.Inflate(e.Bounds, 2, 2);
            args.Cache = e.Cache;
            args.Caption = null;
            args.State = (isfocused) ? ObjectState.Hot : ObjectState.Normal;
            if (usedText )
                e.Appearance.ForeColor = Color.Black;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Painter.Header.DrawObject(args);

            e.Appearance.DrawString(e.Cache,
                                    (usedText) ? employeefullname : e.CellValue.ToString(),//employeefullname, 
                                    Rectangle.Inflate(e.Bounds, -2, -2),
                                    e.Cache.GetSolidBrush(e.Appearance.ForeColor),
                                    e.Appearance.GetStringFormat(TextOptions.DefaultOptionsMultiLine));


        }

        public static void DrawDailyViewCell(RowCellCustomDrawEventArgs e, int index, DailyViewStyle view, StoreDay storeday, EmployeeDayView dayView)
        {
            Rectangle cellBound = Rectangle.Inflate(e.Bounds, 1, 1);

            e.Cache.FillRectangle(Color.White, cellBound);

            Rectangle rect;
            int squareWidth = cellBound.Width;
            Color squareColor = Color.White;
            //int index = infoColumn.FromTime / 15;
            int squareCount = 1;


            if (view == DailyViewStyle.View30)
            {
                cellBound = Rectangle.Inflate(cellBound, -2, 0);
                squareWidth = ((cellBound.Width - 1) / 2);
                squareCount = 2;
            }
            else if (view == DailyViewStyle.View60)
            {
                cellBound = Rectangle.Inflate(cellBound, -2, 0);

                squareWidth = ((cellBound.Width - 3) / 4);
                squareCount = 4;
            }

            int positionX = cellBound.X;
            int currentTime = index * 15;
            Color backColor = Color.White;

            for (int i = 0; i < squareCount; i++)
            {
                currentTime = (index + i) * 15;

                if (!storeday.IsOpeningTime((short)currentTime))
                {
                    backColor = Color.LightGray;
                }
                else backColor = Color.White;

                squareColor = dayView.GetColor(index + i);

                rect = new Rectangle(positionX, cellBound.Y, squareWidth, cellBound.Height);

                if (squareColor == Color.White) 
                    squareColor = backColor;


                e.Cache.FillRectangle(squareColor, rect);
                
                
                positionX += squareWidth + 1;

            }

            e.Handled = true;
        }

        public static void DrawDailyViewCell2(RowCellCustomDrawEventArgs e, int index, DailyViewStyle view, StoreDay storeday, RecordingDayView dayView)
        {
            Rectangle cellBound = Rectangle.Inflate(e.Bounds, 1, 1);

            e.Cache.FillRectangle(Color.White, cellBound);

            Rectangle rect;
            int squareWidth = cellBound.Width;
            Color squareColor = Color.White;
            //int index = infoColumn.FromTime / 15;
            int squareCount = 1;


            if (view == DailyViewStyle.View30)
            {
                cellBound = Rectangle.Inflate(cellBound, -2, 0);
                squareWidth = ((cellBound.Width - 1) / 2);
                squareCount = 2;
            }
            else if (view == DailyViewStyle.View60)
            {
                cellBound = Rectangle.Inflate(cellBound, -2, 0);

                squareWidth = ((cellBound.Width - 3) / 4);
                squareCount = 4;
            }

            int positionX = cellBound.X;
            int currentTime = index * 15;
            Color backColor = Color.White;

            for (int i = 0; i < squareCount; i++)
            {
                currentTime = (index + i) * 15;

                if (!storeday.IsOpeningTime((short)currentTime))
                {
                    backColor = Color.LightGray;
                }
                else backColor = Color.White;

                squareColor = dayView.GetColorByTime((short)currentTime);// (index + i);

                rect = new Rectangle(positionX, cellBound.Y, squareWidth, cellBound.Height);

                if (squareColor == Color.White)
                    squareColor = backColor;

                
                e.Cache.FillRectangle(squareColor, rect);


                positionX += squareWidth + 1;

            }

            e.Handled = true;
        }




        public static void DrawBackgroundWeekDayCell(long storeid, StoreDay storeday, EmployeeDay epd, GraphicsCache cache, Rectangle rect, long storeworldid, bool bFocused, int? long_absence_color)
        {
            Rectangle drawrect = Rectangle.Inflate(rect, 1, 1);
            if (bFocused)
            { 
                Pen pen = cache.GetPen (Color.Black );
                cache.FillRectangle(Painters.FOCUSED_COLOR , drawrect);
                cache.DrawRectangle(pen, drawrect);
            }
            else
            {
                Color color = Color.White;
                if (storeday.Feast) color = Painters.FEAST_COLOR;
                if (storeday.ClosedDay) color = Painters.CLOSEDDAY_COLOR ;
                if (epd.CountDailyAdditionalCharges > 0) color = Painters.ADDITIONAL_CHARGES_COLOR;
                if (epd.StoreWorldId != storeworldid || epd.HasLongAbsence || !epd.HasRelation || storeid != epd.StoreId)
                {
                    color = Painters.DISABLE_COLOR;

                    if (epd.HasLongAbsence)
                    {
                        if (long_absence_color.HasValue)
                            color = Color.FromArgb(long_absence_color.Value);
                    }
                }
                cache.FillRectangle(color, drawrect);
            }

        }

        public static void DrawWeekDayContent(StoreDay storeday, EmployeeDay epd, GraphicsCache cache, Rectangle rect, IRecordingContext context)
        {
            Font cellfont = _cellFont;
            Rectangle cellBound = Rectangle.Inflate(rect, -1, -1);
            Brush cellbrush = Brushes.Black ;
            StringFormat sformat = null;
            if (epd.HasLongAbsence)
            {
                string s = context.LongAbsences.GetAbbreviation(epd.LongAbsenceId);
                if (String.IsNullOrEmpty(s)) return;
                sformat = new StringFormat ();
                sformat.Alignment = StringAlignment.Center;
                sformat.LineAlignment = StringAlignment.Center;
                cache.DrawString(s, cellfont, cellbrush, cellBound, sformat);
            }
            else
            {
                List<string> lstValues = new List<string>();

                List<EmployeeTimeRange> lst = epd.TimeList;

                if (lst != null && lst.Count > 0)
                {
                    sformat = new StringFormat(StringFormatFlags.MeasureTrailingSpaces |
                                            StringFormatFlags.NoWrap);
                    //sformat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces |
                    //                        StringFormatFlags.NoWrap;

                    //cellbrush = Brushes.Black ;
                    Brush absenceBrush = null;
                    string str = String.Empty;
                    int heightCell = (int)(cellBound.Height);// / 2);
                    foreach (EmployeeTimeRange range in lst)
                    {
                        str = range.ToString();//TextParser.EmployeeTimeToString(range);

                        Size sf = cache.CalcTextSize(str, cellfont, sformat, 10000).ToSize ();

                        if (range.Absence == null)
                        {
                            cache.DrawString(str, cellfont, cellbrush, cellBound, sformat);
                        }
                        else
                        {
                            absenceBrush = cache.GetSolidBrush(Color.FromArgb(range.Absence.Color));
                            cache.DrawString(str, cellfont, absenceBrush, cellBound, sformat);
                            
                        }

                        cellBound.Y += sf.Height + 2;
                        heightCell -= (sf.Height + 2);
                        if ((heightCell < 0)) break;//  - (sf.Height + 2)) < 0) break;
                        //if ((cellBound.Y + sf.Height) > (rect.Y + rect.Width)) break;
                    }

                }
            }


        }

        public static void DrawCell(long storeid, IRecordingContext context, EmployeeDay epd, GraphicsCache cache, Rectangle rect, bool bFocused)
        {
            if (context == null) return;
            if (epd == null) return;
            if (cache == null) return;

            StoreDay sd = context.StoreDays[epd.Date];
            DrawBackgroundWeekDayCell(storeid,sd, epd, cache, rect, context.StoreWorldId, bFocused, context.LongAbsences.GetColor (epd.LongAbsenceId ));
            DrawWeekDayContent(sd, epd, cache, rect, context);
        }

        public static void DrawCellWithColor(RowCellCustomDrawEventArgs e, Color color)
        {
            Rectangle cellBound = Rectangle.Inflate(e.Bounds, 1, 1);
            e.Cache.FillRectangle(color, cellBound);
            e.Appearance.DrawString(e.Cache, e.CellValue.ToString(), Rectangle.Inflate(e.Bounds, -2, -2)); 
        }

        public static void DrawWithImage(RowCellCustomDrawEventArgs e, Image image, Color color)
        {
            e.Appearance.BackColor = color;
            e.Graphics.DrawImage(image, image.Size.Width, image.Size.Height);
            e.Appearance.DrawBackground(e.Graphics,e.Cache, e.Bounds);
        }
    }
}
