namespace PixelArt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    static class Patterns
    {
        public static readonly int[][] HORIZONTAL = new int[][] {
        new int[]{1},
        new int[]{0}
        };
 
        public static readonly int[][] VERTICAL = new int[][] {
        new int[] { 1, 0}
        };
 
        public static readonly int[][] DIAGONAL3x3 = new int[][] {
        new int[]{1, 0, 0},
        new int[]{0, 0, 1},
        new int[]{0, 1, 0}
        };  

        public static readonly int[][] DIAGONAL_4x4 = new int[][] {
        new int[]{0, 1, 0, 0},
        new int[]{1, 0, 0, 0}, 
        new int[]{0, 0, 0, 1}, 
        new int[]{0, 0, 1, 0}
        };

        public static readonly int[][] STAR_5x5 = new int[][] {
        new int[]{0, 0, 0, 0, 0},
        new int[]{0, 0, 1, 0, 0},
        new int[]{0, 1, 0, 1, 0},
        new int[]{0, 0, 1, 0, 0},
        new int[]{0, 0, 0, 0, 0}
        };      
 
        public static readonly int[][] SQUARE_5x5 = new int[][] {
        new int[]{0, 1, 0, 1, 0},
        new int[]{1, 1, 0, 1, 1},
        new int[]{0, 0, 0, 0, 0},
        new int[]{1, 1, 0, 1, 1},
        new int[]{0, 1, 0, 1, 0}
        };  
 
        public static readonly int[][] CIRCLE_5x5 = new int[][] {
        new int[]{0, 0, 1, 0, 0},
        new int[]{0, 1, 0, 1, 0},
        new int[]{1, 0, 0, 0, 1},
        new int[]{0, 1, 0, 1, 0},
        new int[]{0, 0, 1, 0, 0}
        };          
 
        public static readonly int[][] WAVE_5x5 = new int[][] {
        new int[] {0, 0, 0, 0, 0},
        new int[] {0, 1, 0, 0, 0},
        new int[] {0, 0, 0, 0, 0},
        new int[] {0, 0, 0, 1, 0},
        new int[] {1, 0, 0, 0, 0}
        };          
 
        public static readonly int[][] GRID_5x5 = new int[][] {
        new int[] {1, 0, 0, 0, 1},
        new int[] {0, 1, 0, 1, 0},
        new int[] {0, 0, 1, 0, 0},
        new int[] {0, 1, 0, 1, 0},
        new int[] {1, 0, 0, 0, 1}
        };      
 
        // {0xFF121212,0xFF3e3e3e,0xFF696969,0xFFc0c0c0,0xFFe0e0e0,0xFFefefef,0xFFffffff}
        public static readonly int[][] DIAG_LIGHT_RIGHT_4x4 = new int[][] {
        new int[] {3, 4, 5, 6},
        new int[] {2, 3, 4, 5},
        new int[] {1, 2, 3, 4},
        new int[] {0, 1, 2, 3}
        };              
 
        // {0xFF121212,0xFF3e3e3e,0xFF696969,0xFFc0c0c0,0xFFe0e0e0,0xFFefefef,0xFFffffff}
        public static readonly int[][] DIAG_LIGHT_LEFT_4x4 = new int[][] {
        new int[] {6, 5, 4, 3},
        new int[] {5, 4, 3, 2},
        new int[] {4, 3, 2, 1},
        new int[] {3, 2, 1, 0}
        };
 
        // {0xFFf4f4f4,0xFFdfdfdf,0xFFc9c9c9,0xFF9f9f9f,0xFFffffff,0xFFeaeaea, 0xFFbebebe,0xFF6a6a6a}
        public static readonly int[][] LIGHT_TOP_4x4 = new int[][] {
        new int[] {0, 4, 4, 0},
        new int[] {1, 5, 5, 1},
        new int[] {2, 6, 6, 2},
        new int[] {3, 7, 7, 3}
        };      
 
        // {0xFF7f7f7f,0xFF404040, 0xFFbfbfbf,0xFFFFFFFF}
        public static readonly int[][] LIGHT_4x4 = new int[][] {
        new int[] {0, 2, 2, 3},
        new int[] {1, 3, 3, 3},
        new int[] {1, 0, 0, 3},
        new int[] {1, 1, 1, 0}
        };
    }
}
