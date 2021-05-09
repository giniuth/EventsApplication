# **EventsApplication**
# CRUD PROJECT

The application I have been creating performs the actions of the requirements, Create, Read, Update and Delete (CRUD). As a small introduction to my application, users will be able to first specify the type of event they would like to host alongside their budget and additionally display an image so the decoration company can help tailor to their requests. Users will then be required to fill in additonal information including the option to have catering provided and a space for them to give us a detailed description into the services they require.

<!-- Blockquote -->
> Here are a few images of the website:

![Screenshot (108)](https://user-images.githubusercontent.com/82108067/117570831-e14d8f80-b0c3-11eb-8aa4-f1ed9167e109.png)![Screenshot (115)](https://user-images.githubusercontent.com/82108067/117570801-caa73880-b0c3-11eb-996a-a91992196fc0.png)


![Screenshot (116)](https://user-images.githubusercontent.com/82108067/117571141-0e4e7200-b0c5-11eb-9da0-9c267f391a18.png)


![Screenshot (117)](https://user-images.githubusercontent.com/82108067/117571148-19090700-b0c5-11eb-9a16-3e0663667aa7.png)

**Summary of app:**
---

<!-- UL -->
* Create an EvenType (Occasion Name) (E.g. Birthday, Wedding, Anniversary, Gender Reveal)

* Users will then set a budget (compulsory)

* Users can attach an inspo picture regarding the theme/design they want

* Users will then tell us what size cake they’d like

**Additional information:**
---

<!-- UL -->
* Users are then required to give us more details including the guest capacity, whether they’d like Alcohol, Catering and if so what Cuisine.

* Users at this point can add a description or give us further details that will help the event company when it comes to planning their specific event.



[This is the link to my Trello Board](https://trello.com/b/ioxDkTOo/qaproject)

Using a Trello board helped me visualise the process clearly and keep track of workflow against the time limit.The benefits of having a visual grid helped me see how much progress I was making. I also kept a column for hurdles/errors I overcame since I do believe its important to note down this information.
<!-- Blockquote -->
> Trello board two weeks into the project

![Screenshot (121)](https://user-images.githubusercontent.com/82108067/117577185-a3ab2f80-b0e0-11eb-947f-f10e01d1cd72.png)

**Entity Relationship Diagram (ERD):** shows the relationship of entities stored in a database. The cardinality type between the two tables would be one to one. There is a *one to one relationship* between the event type and décor details since only one occasion per order can have a service. Additionally, the specifications such as theme/cake design and cuisine will be tailored for that one specific event. We would not be able to provide for a birthday and a wedding unless the two occasions are processed separately. 

[Used Lucid to make ERD Diagrams](https://www.lucidchart.com/pages/)


![Screenshot (123)](https://user-images.githubusercontent.com/82108067/117583621-124bb580-b100-11eb-9bf3-0dcc5b6bfabc.png)

**Risk Assessment**
---

![Screenshot (126)](https://user-images.githubusercontent.com/82108067/117584241-b551fe80-b103-11eb-888d-70a4b6040efe.png)
![Screenshot (128)](https://user-images.githubusercontent.com/82108067/117584242-b6832b80-b103-11eb-9356-95d29a63d168.png)

![Screenshot (102)](https://user-images.githubusercontent.com/82108067/117584519-64430a00-b105-11eb-9443-883756ccfee4.png)
![Screenshot (98)](https://user-images.githubusercontent.com/82108067/117584529-6ad18180-b105-11eb-878e-39987f8a7eb2.png)

![Screenshot (130)](https://user-images.githubusercontent.com/82108067/117584408-afa8e880-b104-11eb-954e-1d597f941bf0.png)
![Screenshot (133)](https://user-images.githubusercontent.com/82108067/117584410-b172ac00-b104-11eb-89d1-e9c4ff935dba.png)
![Screenshot (134)](https://user-images.githubusercontent.com/82108067/117584411-b2a3d900-b104-11eb-836b-1b7190199b6d.png)


![Screenshot (136)](https://user-images.githubusercontent.com/82108067/117584485-3362d500-b105-11eb-8653-6ebf6328977a.png)

**Future improvements:**
---


* I would like to add the '£' sign when adding the budget, even though this company is UK based - it would make the website more credible
* Users might want to add more than one inspo picture, therefore a strategy for this could be implemented
* Users can currently add more than one decor detail therefore I would need to change the code to make it that only one event has one corresponding decordetail
* For the future, contact details and a log in system would be necessary
* There could also be more pictures uploaded from previous events that would help attract more customers and it would be a place for us to showcase our previous work


Author
---

Gini Uthayakumar
