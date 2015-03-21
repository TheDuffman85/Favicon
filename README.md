# Favicon
This C# class provides the favicon of a given url

# Example
```
private void Example()
{
    // Example 1: Synchronous
    PictureBox pb1 = new PictureBox();
    pb1.Image = Favicon.GetFromUrl("http://www.google.de").Icon;

    // Example 2: Asynchronous
    PictureBox pb2 = new PictureBox();
    Favicon favicon = new Favicon();
    favicon.Tag = pb2;
    favicon.GetFromUrlAsyncCompleted += favicon_GetFromUrlAsyncCompleted;
    favicon.GetFromUrlAsync("http://www.bing.de");
}

private void favicon_GetFromUrlAsyncCompleted(object sender, EventArgs e)
{
    Favicon favicon = (Favicon)sender;
    PictureBox pb2 = (PictureBox)favicon.Tag;
    pb2.Image = favicon.Icon;
}
```
