# Local Game Jam 2025: Bubble

## NOTE TO FUTURE READERS
This was my design document I used during the Jam. I'm leaving this as is for anyone who wants to see what the questions I was asking myself. I hope my horrible notes help you on any projects you have.

## Constraints
1. 5-10 minutes average play time
2. Sounds are all made by me, using my awful voice
3. Art will be hand drawn or 2D

## Idea

You are a investor during an egg bubble. You have to invest in egg companies and make as much money as possible before the entire house of cards collapses in on you. The basic mechanic will be buying low and selling high.

Speculation needs to radically inflate the price of these stupid egg companies. There is no reason eggs should be as expensive as I am thinking they will be.

Something will need to burst the bubble and cause a fire sale where the player has to dump their stock. Selling too much stock will also trigger the bubble to burst at specific times.

## Mechanics

### Goal?
I think the player needs to make enough money to afford a house or something. Probably a high score at the end?

### Timer
No days, only every 30 seconds there is an update to the pricing. It will go up unless mentioned in the news article negatively.

So my idea is to set the tics at every 5 to 10 seconds, maybe less.

The market will change states at set intervals, sorta, based on a  random seed at the beginning.

### News
News will operate as random cards that can effect an egg type and it's price.

According to something I saw online, people can read "238 words per minute (wpm) for non-fiction and 260 wpm for fiction." That's like 4 words a second. So if a news story lasts 30 seconds thats 128 words they can read. 

Shoot to read the news in 10 seconds. 

### Bubble Mechanic

Pricing will trade normally for the first minute or so. After that it will enter the bubble era and rapidly build up. Players will have to decide when to sell EGG for profit. The collapse will last only a minute or so in game before returning back to normal pricing.

I'm thinking the bubble will kick in when demand does or something?

#### Bubble Collapse
The bubble will collapse when the price either hits a certain point OR the player sells x percentage of eggs.

I want music to play in this section and there to be a set number of bad news events

### Speculating
Player starts with a finite amount of money and does not gain more unless the sell stock.

### Buying on Margin
I'll see if I can add this. I think the best way of doing this is to go into debt and accrue debt each tic.

## Polish Items
* Intro/Outro
* Egg Music

## News Stories

### Normal
* Nothing could be more normal in the Egg market! - 01 (First)
* Goblins raid multiple coops, [egg] prices set to increase. -02
* China increases target for [egg] in 5-Year Plan. Prices to decrease. -03
* Celebrity share's lifestyle: "I wake up every day and open palm slam an [egg] into the VCR. Then I lift" -04
* Hot new scrambled {ImpactedCommodity.CommodityName} recipe takes nation by storm. -05
* No one wants {ImpactedCommodity.CommodityName} anymore. Millennials and Zoomers to blame. -06

### Bubble
* Eggs could replace dollar -11
* There is nowhere for the price of Eggs to go but up! -12
* "I can't die eggless!!!" Hot new anxiety sweeping the nation -13
* Silicon Valley newest craze is Eggs on the blockchain -14
* A lotta yall still dont get it. You can use multiple slurp juices on a single egg -15
* This can't be sustainable, in this 300 post thread I... -16

### Collapse

* Did the bubble burst? No, the market has always been like this. -21
* There is absolutely no need to panic! -22
* Capitalism is the most rational system that has ever existed -23
* We pissed in the face of God and she is angry -24
* "Look upon my market ye mighty and despair!" Nothing else on the ticker remains (Last) -25

*My name is Patrick Bateman. I’m 27 years old. I believe in taking care of myself, and a balanced diet and a rigorous exercise routine. In the morning, if my face is a little puffy, I’ll put on an ice pack while doing my stomach crunches. I can do a thousand now. After I remove the ice pack I use a deep pore cleanser lotion. In the shower I use a water activated gel cleanser, then a honey almond body scrub, and on the face an exfoliating gel scrub. Then I apply an herb-mint facial masque which I leave on for 10 minutes while I prepare the rest of my routine. I always use an after shave lotion with little or no alcohol, because alcohol dries your face out and makes you look older. Then moisturizer, then an anti-aging eye balm followed by a final moisturizing protective lotion. There is an idea of a Patrick Bateman. Some kind of abstraction. But there is no real me. Only an entity. Something illusory. And though I can hide my cold gaze, and you can shake my hand and feel flesh gripping yours, and maybe you can even sense our lifestyles are probably comparable, I simply am not there.*

## Remaining things to finish
* Intro UI
* Outro UI
* News Events
* Music
* Sounds
* News Event Art
* News Event code
* Bubble Collapse trigger (I think it can fire after x number of speculative events)
