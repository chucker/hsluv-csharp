# Hsluv

[![Build Status](https://travis-ci.org/hsluv/hsluv-csharp.svg?branch=master)](https://travis-ci.org/hsluv/hsluv-csharp)
[![Package Version](https://img.shields.io/nuget/v/Hsluv.svg)](https://www.nuget.org/packages/Hsluv)

[Explanation, demo, ports etc.](http://www.hsluv.org)

## API

This library provides the `Hsluv` namespace with `HsluvConverter` class with
the following static methods. Tuples are three items each: R, G, B and H, S, L.

    IList<double> HsluvToRgb(IList<double> tuple)
	IList<double> RgbToHsluv(IList<double> tuple)
	IList<double> HpluvToRgb(IList<double> tuple)
	IList<double> RgbToHpluv(IList<double> tuple)

	string HsluvToHex(IList<double> tuple)
	string HpluvToHex(IList<double> tuple)
	IList<double> HexToHsluv(string s)
	IList<double> HexToHpluv(string s)

## Building

    mcs -target:library Hsluv/Hsluv.cs

## Testing

See `.travis.yml`.

## Packaging

    $ cd Hsluv
    $ vim Hsluv.nuspec
    $ nuget pack Hsluv.nuspec

## Authors

Mark Wonnacott, Alexei Boronine

# Hsluv.SystemDrawing

This optional library adds integration with `System.Drawing.Color`.

For example, let's take a standard blue and make it lighter:

```csharp
var blue = System.Drawing.Color.Blue; // this will be #0000FF
var blueHsl = blue.ToHsluv(); // lightness will be ~32
var lighterBlue = blueHsl.WithL(50).ToRgb();
```

This converts the color to HSL, adjusts the lightness from about 32 to 50, and then converts the color back to RGB for use in e.g. Windows Forms.

Or, you can take an HSL color you like and freely adjust its hue to get more colors:

```csharp
var jadeGreen = HsluvColor.FromHsl(140, 100, 50);
var pink = jadeGreen.WithH(0);
var gold = jadeGreen.WithH(75);
var teal = jadeGreen.WithH(175);
var blue = jadeGreen.WithH(255);
var purple = jadeGreen.WithH(300);
var springGreen = jadeGreen.WithH(120);
```

On any of those, just call `.ToRgb()` to get them back in RGB form.
