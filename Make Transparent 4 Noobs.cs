// Name: Make Transparent 4 Noobs
// Submenu: Bypassing
// Author: Stiizzy Cat#0001
// Title: Make Transparent 4 Noobs
// Desc: Credits to the make transparent and color cleaer devs! this project would not be possible without their code! 
// Keywords:
// URL: https://forums.getpaint.net/topic/109122-color-clearer/
// Help:
#region UICode
ListBoxControl Color2Show = 0; // Color To Show On|On White| On Black
#endregion


void Render(Surface dst, Surface src, Rectangle rect)
{
if (Color2Show  == 0)
{
    int Rbb = 256, Gbb = 256, Bbb = 256;
    int Rb = Rbb, Gb = Gbb, Bb = Bbb;
    // Save some later multiplications. Might or might not be more efficient.
    int sRb = 255 * Rb, sGb = 255 * Gb,  sBb = 255 * Bb;
    
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        for (int x = rect.Left; x < rect.Right; x++)
        {
            ColorBgra Cf = src[x, y];
            
            int Af = Cf.A;
            if (Af == 0)
            {
                // Optionaly set the transparent pixel to transparent white.
               
            }
            else
            {
                int Rf = Cf.R, Gf = Cf.G, Bf = Cf.B;
                 
                // Alpha-blend the foreground and background colors using the same method
                // as PDN.  The test for alpha == 255 is for efficiency, since it's
                // probably a very common case.
                int Rc, Gc, Bc;
                if (Af == 255)
                {
                    // No blending required.
                    Rc = Rf; Gc = Gf; Bc = Bf;
                }
                else
                {
                    Rc = (sRb + Af * (Rf - Rb)) / 255;
                    Gc = (sGb + Af * (Gf - Gb)) / 255;
                    Bc = (sBb + Af * (Bf - Bb)) / 255;
                }
                              
                // Compute the minimum alpha that will allow the blended pixel color to
                // remain unchanged. The minimum alpha for each individual component
                // is computed, and the maximum of of those alphas is use.
                int Ac = MinimumAlpha(Rc, Rb);
                Ac = Math.Max(Ac, MinimumAlpha(Gc, Gb));
                Ac = Math.Max(Ac, MinimumAlpha(Bc, Bb));
                
                if (Ac == 0)
                {
                    // A non-transparent pixel was made transparent (so the forground color
                    // equals the background color). The color is currently the original
                    // value. Optionally set it to transparent white.        
                }
                else
                {
                    // Compute the new color components for the mimimized alpha.
                    byte r = AdjustForAlpha(Ac, Rc, Rb, Rf);
                    byte g = AdjustForAlpha(Ac, Gc, Gb, Gf);
                    byte b = AdjustForAlpha(Ac, Bc, Bb, Bf);
                    Cf = ColorBgra.FromBgra(b, g, r, (byte)Ac);
                }
            }
                              
            dst[x, y] = Cf;
        }
    }
}

// Find the lowest alpha that will allow this component of the color to remain unchanged
// if blended against the background color.
int MinimumAlpha(int Cc, int Cb)
{
    if (Cc == Cb)
        return 0;
    else if (Cc > Cb)
        return (255 * (Cc - Cb) - 1) / (255 - Cb) + 1;
    else
        return 255 * (Cb - Cc - 1) / Cb + 1;
}

// Adjust the color component for the new alpha so that it remains unchanged if blended
// against the background color. Cm is the color component to match as nearly as possible
// (likely the original foreground color).
byte AdjustForAlpha(int Af, int Cc, int Cb, int Cm)
{
    int T = 255 * (Cc - Cb) - Af * (Cm - Cb);
    if (T <= -255)
        Cm += (T + 255) / Af - 1;
    else if (T > 0)
        Cm += (T - 1) / Af + 1;
    return (byte)Cm;
}

if(Color2Show  == 1)
{
    int Rbbb = 0, Gbbb = 0, Bbbb = 0;
    int Rb = Rbbb, Gb = Gbbb, Bb = Bbbb;
    // Save some later multiplications. Might or might not be more efficient.
    int sRb = 255 * Rb, sGb = 255 * Gb,  sBb = 255 * Bb;
    for (int y = rect.Top; y < rect.Bottom; y++)
    {
        for (int x = rect.Left; x < rect.Right; x++)
        {
            ColorBgra Cf = src[x, y];
            
            int Af = Cf.A;
            if (Af == 0)
            {
                // Optionaly set the transparent pixel to transparent white.
               
            }
            else
            {
                int Rf = Cf.R, Gf = Cf.G, Bf = Cf.B;
                 
                // Alpha-blend the foreground and background colors using the same method
                // as PDN.  The test for alpha == 255 is for efficiency, since it's
                // probably a very common case.
                int Rc, Gc, Bc;
                if (Af == 255)
                {
                    // No blending required.
                    Rc = Rf; Gc = Gf; Bc = Bf;
                }
                else
                {
                    Rc = (sRb + Af * (Rf - Rb)) / 255;
                    Gc = (sGb + Af * (Gf - Gb)) / 255;
                    Bc = (sBb + Af * (Bf - Bb)) / 255;
                }
                              
                // Compute the minimum alpha that will allow the blended pixel color to
                // remain unchanged. The minimum alpha for each individual component
                // is computed, and the maximum of of those alphas is use.
                int Ac = MinimumAlpha(Rc, Rb);
                Ac = Math.Max(Ac, MinimumAlpha(Gc, Gb));
                Ac = Math.Max(Ac, MinimumAlpha(Bc, Bb));
                
                if (Ac == 0)
                {
                    // A non-transparent pixel was made transparent (so the forground color
                    // equals the background color). The color is currently the original
                    // value. Optionally set it to transparent white.        
                }
                else
                {
                    // Compute the new color components for the mimimized alpha.
                    byte r = AdjustForAlpha(Ac, Rc, Rb, Rf);
                    byte g = AdjustForAlpha(Ac, Gc, Gb, Gf);
                    byte b = AdjustForAlpha(Ac, Bc, Bb, Bf);
                    Cf = ColorBgra.FromBgra(b, g, r, (byte)Ac);
                }
            }
                              
            dst[x, y] = Cf;
        }
    }
}

// Find the lowest alpha that will allow this component of the color to remain unchanged
// if blended against the background color.
int MinimumAlphaa(int Cc, int Cb)
{
    if (Cc == Cb)
        return 0;
    else if (Cc > Cb)
        return (255 * (Cc - Cb) - 1) / (255 - Cb) + 1;
    else
        return 255 * (Cb - Cc - 1) / Cb + 1;
}

// Adjust the color component for the new alpha so that it remains unchanged if blended
// against the background color. Cm is the color component to match as nearly as possible
// (likely the original foreground color).
byte AdjustForAlphaa(int Af, int Cc, int Cb, int Cm)
{
    int T = 255 * (Cc - Cb) - Af * (Cm - Cb);
    if (T <= -255)
        Cm += (T + 255) / Af - 1;
    else if (T > 0)
        Cm += (T - 1) / Af + 1;
    return (byte)Cm;
}
}
