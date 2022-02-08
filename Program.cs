// MIT License
//
// Copyright (c) 2022 Sebastien Pouliot
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using SimpleGist;

if (args.Length == 0) {
	Console.WriteLine ("Usage: SimpleGist <file> [<file2> ...]");
	return 1;
}

// The OAuth token is read from environment variable `GITHUB_TOKEN`
// or from the file `~.gist`. You can supply your own token with
// GistClient.OAuthToken = token;

GistRequest request = new () {
	Description = "My private gist",
	Public = false,
};
foreach (var arg in args) {
	if (!File.Exists (arg)) {
		Console.WriteLine ($"File {arg} does not exist");
		return 1;
	}
	request.AddFile (arg, File.ReadAllText (arg));
}

var response = await GistClient.CreateAsync (request);
Console.WriteLine (response.Url);
return 0;
