# .NET Fundamental Concepts

## Question: .NET kya hota hai?

### Answer:
.NET ek software development platform hai jo Microsoft ne banaya hai, jiska use different types ke applications jaise web, Desktop, mobile, gaming, cloud banane ke liye hota hai. Ye C#, F#, VB.Net language ko support karta hai.

.NET ek ecosystem hai, jo ki likhne ke liye language, chalane ke liye runtime, aur libraries provide karta hai jisse developer asani se application bana sake.

---

## Question: Accha to .NET pehle kya tha aur kya pehle application nahi banti thi?

### Answer:
.NET se pehle mainly C/C++ mein programming hoti thi but usme kaafi dikkaten thi jaise:

### 1. Manual Memory Management
Manual memory management karni hoti thi mtlb pehle program mein memory leakage hoti thi. Chalo example se samjhte hain ki actual mein dikat kaha a rahi thi.

Man lo tmne ek variable banaya `sum=0`, aur usko bindas use kara `sum++` karne mein aur return karke tumne print kar diya aur baki ka kaam karne lge program mein. Ab kya hoga kabhi socha hai? 

Tmne jo ye `sum` variable banaya tha usne total memory mein kuch space liya hota. Man lo ki wo `int` tha to 4 byte liya lekar rakha hoga sahi hai na. Chalo ab tum .NET 2002 ke pehle ke developer ho to tumko ye variable free bhi karna hoga print karne ke baad samjheeee aise bhag nahi sakte use karke.

Kyunki 2002 ke bad .NET garbage collector aya aur usne unused variable ki memory free karne ka kaam khud kar liya. 

> **Note:** Garbage collector kaise kaam karta hai ye baad mein dekhenge

### 2. DLL Hell Problem
Ye ek badi dikat thi. Chalo pehle is dikat ko samjhte hain.

Socho ki tmhare machine par 2 application chal rahi hai - `Application1` aur `Application2` aur dono hi application bindas ek DLL jisko ki **Dynamic Link Library** kahte hain usko use kar rahi hai. Socho wo library hai `Math.dll`.

> **Analogy:** Socho ki Tum math mein bahut pakke ho aur bahut tezi se math solve karte ho - jod, guna, bhag aur sab ata hai tmko. Tum tmne basic C program mein ye math sare function bana rakhe hain, aur tum bahut kud rahe ho class mein teacher ke aage. 

Ab socho ki tmhara ek dost hai jo math mein fissadi hai. Magr uski physics theek-thaak hai aur wo bhi programming ke through physics ka program likh raha hai jisme wo velocity, distance, time ye sab calculate karega. 

Waise dekha jaye wo bada kaam kar raha hai, tum to sab jod ghata rhe ho, magar chhodo ye bat abhi. Main bat ye hai ki usko ye math ki cheezein bar bar karni pad rahi hai. Ab usko pta lga ki tmne math ke sare function bana rakhe hain to wo tmse bheekh banagne lga math's wali file. Tmne ye file usko de di aur usne tmhare file ko call karke functions use kar liye.

Accha tmhe pta hai tmne isi beech usko DLL de di hai - ab bhi nahi samjhe? Ye share file hi DLL hai.

#### Ab Main Mudda

Chalo ab main mudde par wapis atte hain. DLL ke chakkar mein fas gya main.

Kaha tha mai... Ha to tmhare system mein do application chal rahi hai - `Application1` aur `Application2`, dono hi ek library use kar rahi hai iska naam hai `Math.dll`.

Ab ek bat samjhte hain - .NET se pehle dll kaha rakhi hoti thi... Ye main question hai!

To dll hoti thi: `C:\Windows\System32\Math.dll`... to yaha pe hoti thi dll.

Ab dono application same dll ko use karke khush thi. Yadd rahe same dll, same version. 

Magar socho - `Math.dll` ke owner ne kuch aur function add karke iska naya version nikal diya aur `Application1` ke developer ko wo naye function pasand aye. Wo usne pehle application mein wo function use kar liye. Uska code to bindas chal raha hai magar uske local system pe.

Jaise hi wo apne application prod pe le jayega `Math.dll` naye version se replace ho jayegi aur `Application2` fat jayegi.

Aur kisi ko pta nahi chalega issue kaha hai... Ab dhundo!

**Iska solution chahiye!**

#### .NET ne kya Solution Diya?

Chalo dekhte hain .NET ne kya solution diya:

##### Solution 1: Private Assemblies
Sabse pehle to ye ki dll ko shared na rakh kar mtlb `C:\windows\system32\Math.dll` ki jagah, alag alag project ke andar rakhna. Mtlb `Application1` ka dll folder alag hai aur `Application2` ka alag. Isko angrezi mein **Private Assemblies** bolte hain.

Ek bat samjho - yaha Microsoft developer ne isko apni bhasa mein soch aur samjh ke banaya hoga. Uske baad jab ban gya to angrezi naam diya to angrezi se daro mat karo!

##### Solution 2: Strong Naming & Metadata
Chalo age badte hain. Iske baad aur kya kiya...

Accha to jo dikat thi ki ek hi version system mein rakh sakte hain, abhi puri tarah se solve nahi hue. Private assemblies rakhne mein ek dikat hai - ham sari assemblies private nahi rakh sakte. Kyun nahi rakh sakte?

Wo isliye ki har bar dll choti si file nahi hoti. Kayi bar ye badi file - jyada MB ki hoti hai. Aur socho ki agar tmhare pas 5 applications hain to 5 jagah same file le jaoge. Aise samjhte hain ki 5 applications same dll use kar rahi hain. Ab unme se ek ne us dll ka bada version dal diya to fir se ham wahi fas gye.

Iska solution hai ki ham multiple versions allow kare. Hai na! 

Magar multiple versions ki dll to ham aaj bhi store kar skte hain to isme .NET ki jyada zarurat... Simple 2 file dal do with version name aur bas. Ha ha kuch aisa hi .NET ne kiya!

**Samjhte hain kya kiya:**

Sabse pehle to .NET ne apni library ko kuch metadata diya identity ke liye - sirf name nahi aur bhi kuch, jaise:
- **Name**
- **Version**
- **Culture**
- **Public Key Token**

Ye sab info DLL ke andar embedded hoti hai. Accha ye cheezein C/C++ mein nahi thi, usme sirf Name hi malik tha!

Ab CLR (jo ki ham age dekhenge kya hota hai...) jab DLL lene jayega to ye 4 cheezein match karega. Ya jab install karega to purane wali override nahi karega kyunki ye 4 cheezein har version ki alag hongi.

**Problem Solved!** Ha ab angrezi suno... Isko kahte hai **Side-by-Side Versioning**

##### Solution 3: GAC (Global Assembly Cache)
Accha isme ab ek bat aur dekh lo - .NET ne GAC mtlb **Global Assembly Cache** karke ek system level pe folder banaya hai jisme wo sari common use hone wali dll rakhta hai. 

Ab 10 applications un common dll ko aaram se use kar sakti hain. Private karne ki zarurat nahi aur ha isme side-by-side versioning mein hoti hai.

##### Solution 4: Binding Redirect (Bonus)
Ye ek bonus de deta hoon yaha:

```xml
<bindingRedirect oldVersion="1.0.0.0" newVersion="2.0.0.0" />
```

Ye dekha hoga na app.config mein? Kabhi socha ye kya hai? Kyun hai? Version update kiya aur naya version `NewVersion` mein aya aur age bad gye... Kabhi socha ki ye `OldVersion` kyun rakha hai yaha?

Ye ek bada concept hai. Isko samjhte hain:

To samjho ki tmne ek library use ki apne code mein aur wo prod pe fat gya. Mtlb us library mein ek bug tha. Ab... ab kya hoga socho...

Tmne us team ko inform kara jisko ye library hai aur usne ye bug fix karke naya version release kar diya. Uska kaam khatm aur tmhara suru... Ab kya karoge?

Codebase mein naya version loge, build banegi, release hogi aur production downtime ayega. 

Lekin socho ki ye sab **bina downtime** ya **kam downtime** aur **bina nayi build** banaye, **bina naya release** kiye ho sakta hai to - socho kaise?

**App.config** mein jakar `NewVersion` mein naya version dal do prod pe aur naya NuGet share location jaha se old NuGet pada hai wha dal do, aur fir app restart.

Jab app start hota hai to CLR app config mein jakar ye dekhti hai ki kis version ke against naya version le skte hain. Ab bhale hi code mein older version pada hai lekin **Naye NuGet use hoga runtime mein**.

Isme bas ek condition hai ki **naya version backward compatible hona chahiye**.

> **Yaar ek doubt aa rha hai:** Ham har NuGet ko app.config mein to nahi dalte?
> 
> **TODO:** Isko ham aur detail mein samjhenge abhi age badte hain
	 


