using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace UltraLongMonogameTutoriel.Managers
{
    internal static class DragDropManager
    {
        private static readonly List<IDraggable> draggables = new List<IDraggable>();
        private static IDraggable dragItem;
        private static Point dragOffset;
        private static bool isDragging = false;

        public static void AddDraggable(IDraggable draggable)
        {
            draggables.Add(draggable);
        }

        private static void CheckDragStart()
        {
            if (Globals.Drag & !isDragging)
            {
                foreach (var draggable in draggables)
                {
                    if (draggable.rect.Contains(Globals.MouseCursor.Location))
                    {
                        dragItem = draggable;
                        isDragging = true;
                        dragOffset = new Point(Globals.MouseCursor.X - draggable.rect.X, Globals.MouseCursor.Y - draggable.rect.Y);
                        break;
                    }
                }
            }
        }

        private static void CheckDragStop()
        {
            if (!Globals.Drag && dragItem != null)
            {
                dragItem = null;
                isDragging = false;
            }
        }

        public static void Update()
        {
            CheckDragStart();
            if (dragItem != null)
            {
                dragItem.rect = new Rectangle(
                Globals.MouseCursor.X - dragOffset.X,
                Globals.MouseCursor.Y - dragOffset.Y,
                dragItem.rect.Width,
                dragItem.rect.Height
            );
            }
            CheckDragStop();
        }
    }
}
