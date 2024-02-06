using PuppeteerSharp;

using var browserFetcher = new BrowserFetcher();
await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
var browser = await Puppeteer.LaunchAsync(new LaunchOptions
{
    Headless = false
});
var page = await browser.NewPageAsync();
await page.GoToAsync("https://www.colruyt.be/fr/produits?page=1");



await page.WaitForSelectorAsync("p.card__text");



var elements = await page.EvaluateFunctionAsync<string[]>(@"() => {

 

    var elements = [];
    document.querySelectorAll('p.card__text').forEach(e => elements.push(e.innerText));
    return elements;

 

}");



foreach (var e in elements)
    Console.WriteLine(e);
