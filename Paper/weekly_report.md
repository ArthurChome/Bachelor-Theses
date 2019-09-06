
# Weekly report

## Here you write your weekly report about the related work.

## Week 1 `29/10/2018`:
----------------------

### Evans2017: Evaluating the Microsoft HoloLens through an augmented reality assembly application
Augmented reality’s forecasted market revenue will be around 80 billion US Dollars by 2021. 
Those incredible numbers have drawn the attention of many technology firms that each have by consequence developed their own products for the market.
For Microsoft, its newest tool for augmented reality is the HoloLens. 
This technology now gets used in -for instance- training videos for assembly and manufacturing lines.

Augmented reality -due to technical limitations at the time- used to be solely developed for use on tablets and mobile phones. 
This limited the user’s movements and degree of interaction with the physical world. 
The technological advancements of recent years have allowed us to create hands-free Head Mounted Display devices. 
The user is now able to reduce unnecessary movements, being able to fully concentrate on the mixed environment without having to bother with the rendering hardware.

While moving away from hand-held devices offers greater freedom to the user, the down side comes when designing new user interfaces for new delivery devices. 
The traditional input devices like touchscreens or keyboards are a thing of the past. The HoloLens therefore focuses on gesture interactions.

The Microsoft HoloLens is special in the sense that it’s the first commercially available head mounted display for augmented reality. 
Before this model, HMD’s used to be quite expensive and custom made for research.

The rest of the article focuses on the application of a mixed reality environment to educate people to use an assembly line.
 This brand new technology allows the user to dynamically see exactly where a part, fastener, or tool must go. 
 The biggest challenge in this is creating effective user interfaces.

Since the Microsoft HoloLens will have a major role in the theses, I figured it would be wise to choose at least one article about it. 
The article itself offered an interesting summary about the evolution of head mounted display devices and how the HoloLens came to be.


### Honig2015: Mixed Reality for Robotics
This article offers a detailed discussion in the difference between mixed, augmented reality and augmented virtuality as well as the benefits of mixed reality for the development of robotics and the possible applications of it in that field of science.

The article is clear: mixed reality is the science of creating a new world by merging elements of the physical world and the virtual world. 
The defining feature for MR hereby is its ability to allow for direct interaction between physical and virtual environments.

It should also be noted that we make this distinction between Augmented Reality and Augmented Virtuality which are special instances of mixed virtual reality. 
In Augmented Reality, virtual objects are projected onto the physical environment, while in Augmented Virtuality, physical objects are incorporated into a virtual environment.

The article claims that the benefits in the scientific field of robotics are substantial. 
For instance, thanks to what we call spatial flexibility, mixed reality allows us to perform experiments with robots remotely. 
This is because separate research groups aren’t separated anymore by geographical constraints. 
They can meet in a virtual environment instead of having to travel great distances to witness tests on their machines.

Another advantage is the enormous safety benefits linked to using virtual environments. 
Human-machine interaction would be a thing of the past and interaction would happen solely with virtual models. 
Potential harm to human test subjects is now impossible.

Mixed reality also makes for an enriched environment where all physical and virtual data interact directly in real-time; no further computation or calculation is necessary.
 This expedites and simplifies debugging because the difference between implementation and simulation becomes even smaller. 

A virtual environment allows adding or changing virtual features of robots that may be too costly, time-consuming, or impossible in reality. 
In our case, this would not be necessary. As an extra feature, it would maybe be cool to add some kind of virtual decoration to the Lego robot.

Aside from the benefits, the article also mentions some examples of mixed virtual reality. 
An example would be MR for testing a swarm of unmanned aerial vehicles that are supposed to follow a human around. 
By letting them follow a virtual approximation of a human, some potential safety hazards for the human when testing are avoided.

The article offers great details about the benefits and applications of virtual reality in the field of robotics and the interaction between physical and virtual components of the environment. 
For my mixed reality application to work, it must be able to properly interact with the virtual objects.
 That’s way it was such a good read.

 
### Kyto2018: Pinpointing: Precise Head- and Eye-Based Target Selection for Augmented Reality
The paper discusses the potential of eye gaze and head movement as a way for the user to insert useful input when using a head mounted display device. 
It’s a natural way to interact with the environment and doesn’t require extra hardware to be implemented.

While initially used for measuring and understanding users’ focus and attention, eye gaze has been actively investigated as an input method. 
The problem -however- is that eye gaze tends to be inaccurate due to human physiology and tracking system limitations. 
Another problem is that eye movement reflects not only conscious but also unconscious eye movement. 
As a result, eye-based input suffers from involuntarily selection. The solution for this would be the technique of Pinpointing: a multimodel pointing refinement technique for wearable augmented reality devices.

Handy because the user will have to use eye gaze to steer the Lego robot’s fire on the enemy objects. 
The paper gets too mathematical at times but is in general a good explanation on how the pinpointing technique works.

### Liarokapis2007: An Augmented Reality Interface for Visualizing and Interacting with Virtual Content
The article offers a detailed report on the history of augmented reality user interfaces as well as the key features a good interface should provide to the user.
 It also contains some examples of good interfaces.

Vision-based augmented reality interfaces highly depend on four key elements. The first one are marker implementations. 
Markers are feature points that are used to estimate the camera pose relative to the user to calculate how the interface should position itself. 
The second element refers to calibration techniques to correctly setup the camera sub-system.
 These elements are thus related to the technical implementation of the interface.

The other two key elements are related to the construction of software user interfaces that will allow the effective visualisation and manipulation of the virtual information. 
In other words: the presentation of the data.

The article highlights some important technical issues in making an interface work like proper camera calibration. 
This information might come in handy.

### Walker2018: Communicating Robot Motion Intent with Augmented Reality
This article contains a series of explicit and implicit designs for visually signalling robot motion intent using augmented reality. 
This is interesting for our theses since our intent is to steer the robot with hands-free augmented reality. 

In total, the article discusses four designs for communicating robot intent: NavPoints, Arrows, Gaze and Utilities. 
The most relevant of these for our topic is the Utilities design: it’s a method for augmenting our user interface to provide contextual information in an egocentric manner.  
This design displays a 2D circular “radar” fixed at the bottom left corner of the ARHMD display. 
When the robot is in the user’s field-of-view, it is overlaid with a targeting box, when not in the FOV, an off-screen indicator appears in the form of a directional arrow. 
When in front of the user’s field-of-view it will try to follow the user accordingly. 
Therefore, it visually communicates motion cues for the robot. 

The article believes augmented reality holds potential for improving human-robot interactions. 
However, this area of science is critically understudied and represents a relatively new research space, especially within the context of the capabilities provided by modern augmented reality head mounted display hardware. 



## Week 2 `04/11/2018`:
----------------------

### Lupu2013: A Survey of Eye Tracking Methods and Applications
Content
This paper discusses eye tracking techniques to calculate the user’s eye gaze as to know what the user’s looking at. 
The positioning of the eyes could be used as a new user interaction technique with the mixed virtual environment.
An eye tracking system is based on a device to track the movement of the eyes to know exactly where the person is looking and for how long. 
It also involves software algorithms for pupil detection, image processing, data filtering and recording eye movement by means of fixation point, fixation duration and saccade as well.
A large variety of hardware and software approaches were implemented by research groups or companies according to technological progress. The suitable devices for eye movement acquiring and software algorithms are chosen in concordance with the application requirements.

Relevance
This paper is useful because in the end we’ll have to steer a physical robot remotely without some kind of controller but based on eye gaze.
The robot must also be able to see the virtual objects in the environment that we can observe with our head-mounted device.

### Coutrix2006: Mixed Reality: A model of Mixed Interaction
Content
Although mixed reality systems are becoming more prevalent, we still do not have a clear understanding of this interaction paradigm. 
Addressing this problem, this article introduces a new interaction model called Mixed Interaction model. 
It adopts a unified point of view on mixed reality systems by considering the interaction modalities and forms of multimodality that are involved for defining mixed environments. 
This article presents the model and its foundations. 

Relevance
Could be useful since user interaction with the mixed reality environment is an important aspect of the project.

### Vovk2018: Simulator Sickness in Augmented Reality Training Using the Microsoft HoloLens
Content
Augmented reality is on the rise. The surge of this research field has prompted a lot of hardware manufacturers to develop their own products for it. 
This has caused the required hardware like head-mounted devices to become increasingly more prevalent and commercially available on the consumer market. 
A big problem with augmented reality is the notion of motion sickness caused by the head-mounted devices. 
Their side-effects on the user have remained so far under-explored in the research world.
The paper addresses this problem by conducting a series of experiments on three different industries: aviation, medical and space. 
What’s especially interesting for us here, is that the tests are performed on the Microsoft HoloLens: a head-mounted device that we’ll be using for this bachelor theses. 
The results of the experiments are promising: the HoloLens only causes negligible symptoms of simulator sickness. 
Most consumers who use it will face no symptoms while only few experience minimal discomfort in the training environments that was tested.

Relevance
Since we’ll be using the Microsoft Hololens quite a lot, it might be useful to inform us about the potential side-effects it may have on its users. 
Again: the HoloLens doesn’t seem to have a lot of safety risks, just the minor discomfort of motion sickness at most.

### Rogers2018: Vanishing Importance: Studying Immersive Effects of Game Audio Perception on Player Experiences in Virtual Reality
Content
The paper analyses the use of sound to create a more immersive virtual experience. 
It indicates that audio is an important factor for inducing presence in games, it would be nice to apply it to our virtual application. 
The best way to impose presence is through sound quality and spatialization. 
The results from the initial study suggest that audio takes a less significant role for most players in virtual reality, because they focus more on the sensory experience and exploratory gameplay.

Relevance
The use of sound could be a nice touch for the final product. 
The virtual objects could emit a sound when hit by the robot. 
This would indicate to the player that it hit something.

### Egges2007: Presence and interaction in mixed reality environments
Content
The paper offers a simple and robust mixed reality framework that allows for real-time interaction with virtual humans in mixed reality environments.
The software architecture is composed of multiple software components called services, as their responsibilities are clearly defined. 
They have to take care of rendering of 3D simulation scenes and sound, processing inputs from the external VR devices, animation of the 3D models,...

Relevance
While our application will not have virtual humans in it, it will have virtual objects with whom the robot must interact with. 
The framework discussed here will maybe come in handy once we start programming the application.

### Krevelen2010: A Survey of Augmented Reality Technologies, Applications and Limitations
Content
The article is a detailed look on augmented reality and associated technologies and how it slowly grows as a research field. 
It contains a brief history summary and discusses the enabling technologies in the field. 
The field of augmented reality comes with quite some limitations too due to it being a new field of science. 
Portability, tracking, calibration and social acceptance are examples of the limitations the field suffers from.

Relevance
This article can be useful to write out the introduction for the bachelor research paper. 
It contains a lot of information on the subject matter and discusses the difference between virtual, augmented and mixed reality. 
With over hundred references this survey is a comprehensive investigation into augmented reality. 
It represents a suitable starting point for readers new to the field.

### Zhou2008: Trends in Augmented Reality Tracking, Interaction and Display: A Review of Ten Years of ISMAR
Content
This paper reviews the ten-year development of the work presented at the ISMAR conference and its predecessors with a particular focus on tracking, interaction and display research. 
The International Symposium on Mixed and Augmented Reality (ISMAR) is the leading international conference in augmented and mixed reality. 
It provides a roadmap for future augmented reality research which will be of great value to this relatively young field and also for helping researchers decide which topics should be explored when they are beginning their own studies in the area.

Relevance
This detailed overview on the latest developments in mixed reality and the future research trends in the field is very useful for me: a student informing himself on his research topic.

### Ribo2001: A new Optical Tracking System for Virtual and Augmented Reality Applications
Content
A new vision tracker setup for virtual and augmented reality applications is presented in this paper. 
Performance, robustness and accuracy of the system are achieved under real-time constraints. 
The method is based on blobs extraction, two-dimensional prediction, the epipolar constraint and three-dimensional reconstruction. 
Experimental results using a stereo rig setup (equipped with IR capabilities) and retroreective targets are presented to demonstrate the capabilities of our optical tracking system.

Relevance
This tracking technique might be useful for tracking virtual elements in the application we’ll have to program.

### Green2008: Human-Robot Collaboration: A Literature Review and Augmented Reality Approach in Design
Content
Making human-robot collaboration natural and efficient is crucial. 
In particular, grounding, situational awareness, a common frame of reference and spatial referencing are vital in effective communication and collaboration. 
Augmented Reality, the overlaying of computer graphics onto the real worldview, can provide the necessary means for a human-robotic system to fulfill these requirements for effective collaboration. 
This article reviews the field of human-robot interaction and augmented reality, investigates the potential avenues for creating natural human-robot collaboration through spatial dialogue utilizing AR and proposes a holistic architectural design for human-robot collaboration.

Relevance
Might be useful for the interaction between the robot and the user.

### Olwal2003: The Flexible Pointer: An Interaction Technique for Selection in Augmented and Virtual Reality
Content
The paper discusses a new technique for human-robot interaction in a mixed reality environment. 
The technique uses a pointer that’s virtually generated in front of the user and allows him to select elements more precisely.
Key in steering this pointer is hand orientation: it determines the amount of curvature, and position is mapped to length. 
For increased precision and comfort, the current implementation uses twohanded control of the pointer.

Relevance
Using a pointer to steer the robot could be a good way to interact with it.


## Week 3 `13/11/2018`:

### Comport2003: A real-time tracker for markerless augmented reality
Augmented Reality has now progressed to the point where real-time applications are being considered and needed. At the same time it is important that synthetic elements are rendered and aligned in the scene in an accurate and visually acceptable way. 
This article covers a new algorithm for markerless augmented reality: this means tracking elements of the real-world and overlaying it with virtual computer-generated objects gets done without any prior knowledge of the environment. This means that a mixed reality application can be applied on the fly to pretty much any environment.
To highlight the efficiency of the algorithm, the researchers here have conducted a series of experiments. These includes experiments in an indoor and outdoor environment as well as guided maintenance of an airconditioning system. In all these experiments, the result of the algorithm is very promising.

### Datcu2013: Free hands interaction in augmented reality
Interaction is unquestionably very important for our mixed reality game. It would not exist without a seamless human-robot communication. This article presents a novel approach in free-hands tracking to support user interaction in augmented reality. The approach makes it possible to compare different types of hand-based interaction in AR for navigating using a spatial user interface.

### Walton2017: Accurate Real-time Occlusion for Mixed Reality
Occlusion means hiding virtual objects behind real things. It’s an aspect of mixed reality that is important for any application in that domain. The problem is that existing methods typically require some proper foreknowledge (geometry) of the physical objects on which occlusion must be applied. Either manually specified of reconstructed by some convoluted image processing algorithm.
The paper contains a method that would allow us to improve inclusion by way of using color and depth information provided by way of a visual sensor or a camera simply said.

### Ajanki2011: An augmented reality interface to contextual information
This article focuses on the problem of how to efficiently retrieve and present contextual information in real-world environments where it is hard to formulate explicit search queries and the temporal and spatial context provides potentially useful search cues. In other words, the user may not have an explicit query in mind or may not even be searching, and the information relevant to him or her is likely to be related to objects in the surrounding environment or other current context cues. 
The experiments have the user wear data glasses and sensors measuring his or her actions, including gaze patterns and further, the visual focus of attention. Using the implicit measurements about the user’s interactions with the environment, we can infer which of the potential search cues (objects, people). 
This might come in handy for when our application tracks the used robot or wants to deduce handy information about the environment to position the virtual elements or detect when there was a target hit.

### Koelle2014: Human-Computer Interaction with Augmented Reality
This technical report gives a brief introduction to Augmented Reality and provides an overview of user-centered research methods that are available to Augmented Reality development as well as interaction methods and technologies. This report is pretty general for our research topic so it should come in handy.

### Raskar2002: Interacting with Spatially Augmented Reality
The focus of the paper is on projector based augmented reality applications. It describes various underlying techniques and discusses the results in the context of three different applications. New concepts include the notion of Spatially Augmented Reality. In it, the user’s physical environment is augmented with images that are integrated directly in the user’s environment, not simply in their visual field. 

### Milgram2014: Augmented Reality: A class of displays on the reality-virtuality continuum
The paper discusses Augmented Reality in a pretty general sense encompassing a large class of mixed reality displays. We introduce the notion of Spatially Augmented Reality: in it, the user’s physical environment is augmented with images that are integrated directly in the user’s environment, not simply in their visual field. 

### Narzt2006: Augmented reality navigation systems
The paper discusses improvement techniques for navigation in augmented reality environments. It discusses ways of dramatically decreasing the used sensors and hardware to gain cost benefits. It also presents an experiment to illustrate the improvement techniques by way using a car as an augmented reality apparatus. Using an innovative visualization paradigm for navigation systems, it enhances user interaction considerably.

### Acharya2013: Perceptual issues in designing Augmented Reality
To gain a better understanding of augmented reality, it might be handy to think about the current flaws and issues this brand-new research field currently faces. AR works by adding computer-generated information to the physical world to enhance the viewer’s perception.  As a result, we see perceptual issues interfere in performing task at hand using these systems. In this paper, we discuss some of the known depth issues in augmented reality. The paper also discusses some more specific problems in the field after covering the more general ones.


## Week 4 `19/11/2018`: 


### Kruijff2010: Perceptual Issues in augmented Reality Revisited
This paper discusses some issues we might be confronted with when developing an augmented reality system. The article goes to great extend in classifying these problems. Environment problems for instance relate to issues in the interplay between the environment and the augmentations. 
Capturing issues relate to digitizing the environment in video see-through systems, in other words the process of converting an optical image to a digital signal by a camera, thus defining the first stage of providing a digital representation of an environment. Augmentation issues relate to the design, layout and registration of augmentation. Then there are the technical issues related to current hardware limitations or just caused by the user itself who may sometimes ignore how a system works.

### Mestre2015: Immersion and Presence
Immersion is defined as the sensation of presence or the sensation of really being in the environment recreated with augmented reality. Immersion is achieved by removing as many real-world sensations as possible and substituting these with the sensations corresponding to the virtual environment. 
One of the subjects of the article are the (not-so-precise) measurement tools for the sense of immersion that users feel. These measurements are performed by questionnaires and focus more on the user’s cognitive processes such as attention and situational awareness.
Another measurement tool mentioned was that of behavior: how do users act when in this virtual environment? Motorically, for instance, they may include reaching for a virtual object, socially reacting to avatars, ... These reflex-like responses could provide indicators of presence.

### Ismar2011: KinectFusion: Real-Time Dense Surface Mapping and Tracking
The previous year, the intention of the mixed reality thesis was building a ‘museum of the future application’ that mapped a museum tour on a pre-determined environment with a clearly scheduled trajectory.
The difference and challenge this year is implementing a mixed reality game that could work on any environment (within the bounds of feasibility of course). For this purpose, we need efficient real-time mapping algorithm. This is exactly what this paper present applied to “complex and arbitrary indoor scenes in variable lighting conditions”. The best news is that this technology requires minimal hardware like a low-cost depth camera.

### Anderson2009: Distance Perception in NPR Immersive VE, Revisited
The paper discusses how to effectively use rendering in immersive virtual environments to enable the intuitive exploration of early architectural design concepts at full scale. Previous studies have shown that people typically underestimate egocentric distances in immersive virtual environments, regardless of rendering style. The report discusses results of an experiment that seeks to assess the accuracy with which people judge distances in a non-photo realistically rendered virtual environment that is a directly-derived stylistic abstraction of the actual environment that they are currently in.

### Holz2009: Where Robots and Virtual Agents Meet 
The whole article focuses on the interaction of virtual agents (computer-generated) and robots (phsycally present). Though it specifically focuses on the social side of interaction, the way they do it and the gear used (by preference as cheap as possible) might be interesting for our research question. If the paper doesn’t mention any cheap way of communicating the presence and position of the virtual agents to the robot, his might solidify our problem statement even further: there’s no low-cost way to make the robot see the virtual agents.


## Week 6: '03/11/2018':
#### Al-Saedi2014: Implementation of Path Finding Algorithms in a 3-Dimentional Environment
This paper discusses the use of the path finding algorithms in a 3-Dimensional (3D) military training environment. It describes how to represent the nodes in a 3D environment. Two algorithms are used: the Waypoint Navigation and the A* path finding algorithm. A comparison between the
two path finding algorithms is made to evaluate their performance. Also, a solution to the problem of finding the first node to go to by the object is solved.