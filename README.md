# Cataclysm DDA News
GitHub check service and newsfeed site, that automaticaly checks events from CleverRaven/Cataclysm-DDA repo

## By this moment it is temporarily hosted on [**cataclysmnews.rf.gd**](http://cataclysmnews.rf.gd)

<img src="https://raw.githubusercontent.com/BastardFat/cataclysm-news/master/logo.png" alt="logo" style="width: 800px;"/>

### Uses:
- C# (GitHub service)
	- [*Newtonsoft.Json*](https://github.com/JamesNK/Newtonsoft.Json "GitHub link") nuget for (de)serializing json
	- [*Markdig*](https://github.com/lunet-io/markdig "GitHub link") for converting markdown to HTML
	- [*Telegram.Bot*](https://github.com/MrRoundRobin/telegram.bot "GitHub link") for sending notifications
- PHP (site back-end)

- HTML + CSS + JS front-end:
	- [*Bootstrap*](https://github.com/twbs/bootstrap "GitHub link")
	- [*jQuery*](https://github.com/jquery/jquery "GitHub link")

### Version 0.1:
- Checks `PullRequestEvent` and `IssueEvent`
- Updates site's newsfeed
- Sends notifications from Telegram bot

