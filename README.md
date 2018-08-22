# ImageFit
ImageFit is a simple set of utility methods for scaling, cropping or stretching an image to make it fit certain dimensions. 
It's like a .NET equivalent to the CSS [object-fit](https://developer.mozilla.org/en-US/docs/Web/CSS/object-fit) property.

Available as a [NuGet package](https://www.nuget.org/packages/ImageFit/) for .NET Standard 2.0.

## Usage
In the following examples `sourcePath` is the filepath to an image with a width of 1000 pixels and a height of 1000 pixels.

#### Image.Cover

```c#
// This will produce a down-scaled 800 x 600 image with cut-offs on the top and bottom:
Image.Cover(sourcePath, destinationPath, 800, 600);

// This will produce an up-scaled 1200 x 1600 image with cut-offs on the left and right sides:
Image.Cover(sourcePath, destinationPath, 1200, 1600);
```

#### Image.Contain

```c#
// This will produce a down-scaled 600 x 600 image:
Image.Contain(sourcePath, destinationPath, 800, 600);

// This will produce an up-scaled 1200 x 1200 image:
Image.Contain(sourcePath, destinationPath, 1200, 1600);
```

#### Image.Fill

```c#
// This will produce a down-scaled 800 x 600 image that appears stretched horizontally:
Image.Fill(sourcePath, destinationPath, 800, 600);

// This will produce an up-scaled 1200 x 1600 image that appears squeezed horizontally:
Image.Fill(sourcePath, destinationPath, 1200, 1600);
```

#### Image.ScaleDown

```c#
// This will produce a down-scaled 600 x 600 image:
Image.ScaleDown(sourcePath, destinationPath, 800, 600);

// This will produce an image with the original 1000 x 1000 dimensions (no upscale):
Image.ScaleDown(sourcePath, destinationPath, 1200, 1600);

```
