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
    internal interface IDraggable
    {
        Rectangle rect { get; set; }

        void RegisterDraggable()
        {
            DragDropManager.AddDraggable(this);
        }
    }
}
