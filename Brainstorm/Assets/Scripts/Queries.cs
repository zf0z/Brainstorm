using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Queries
{
    

    public static string CreateSubjectsTableQuery = "DROP TABLE IF EXISTS Subjects; " +
                                                    "CREATE TABLE Subjects (" +
                                                    "Id INTEGER PRIMARY KEY, " +
                                                    "SubjectName VARCHAR(30))";

    public static string CreateTopicsTableQuery = "DROP TABLE IF EXISTS Topics; " +
                                                    "CREATE TABLE Topics (" +
                                                    "Id INTEGER PRIMARY KEY, " +
                                                    "TopicName VARCHAR(30), " +
                                                    "SubjectId INTEGER, " +
                                                    "HighScore INTEGER DEFAULT 0," +
                                                    "FOREIGN KEY(SubjectId) " +
                                                    "REFERENCES Subjects(Id))";

    public static string CreateFlashcardsTableQuery = "DROP TABLE IF EXISTS Flashcards; " +
                                                    "CREATE TABLE Flashcards (" +
                                                    "Id INTEGER PRIMARY KEY, " +
                                                    "Question TEXT, " +
                                                    "Answer TEXT, " +
                                                    "Included INTEGER DEFAULT 1, " +
                                                    "TopicId INTEGER, " +
                                                    "FOREIGN KEY(TopicId) " +
                                                    "REFERENCES Topics(Id))";

    //The tables required in the database
    public static List<string> CreateTablesQueries = new List<string>
    {
        CreateSubjectsTableQuery,
        CreateTopicsTableQuery,
        CreateFlashcardsTableQuery
    };


    public static string InsertMathsIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (1, 'Maths')";
    public static string InsertEnglishIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (2, 'English')";
    public static string InsertPhysicsIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (3, 'Physics')";
    public static string InsertChemistryIntoSubjects = "INSERT INTO Subjects(Id, SubjectName) VALUES (4, 'Chemistry')";

    //The data required in the subjects table
    public static List<string> InsertIntoSubjectsQueries = new List<string>
    {
        InsertMathsIntoSubjects,
        InsertEnglishIntoSubjects,
        InsertPhysicsIntoSubjects,
        InsertChemistryIntoSubjects
    };

    //Maths
    public static string InsertFactorsIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (1, 'Factors', 1)";
    public static string InsertNumbersIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (2, 'Numbers', 1)";
    public static string InsertFractionsIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (3, 'Fractions', 1)";
    public static string InsertPercentagesIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (4, 'Percentages', 1)";
    public static string InsertTrigonometryIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (5, 'Trigonometry', 1)";
    
    //English
    public static string InsertEnglishTermsIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (6, 'English Terms', 2)";
    public static string InsertRomJulCharsIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (7, 'Romeo & Juliet Characters', 2)";

    //Physics
    public static string InsertSpecificHeatCapacityIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (8, 'Specific Heat Capacity', 3)";
    public static string InsertElectricityIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (9, 'Electricity', 3)";
    public static string InsertForcesIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (10, 'Forces', 3)";
    public static string InsertVisibleLightIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (11, 'Visible Light', 3)";

    //Chemistry
    public static string InsertAtomicStructureIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (12, 'Atomic Structure', 4)";
    public static string InsertMetallicBondingIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (13, 'Metallic Bonding', 4)";
    public static string InsertTypesOfStructureIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (14, 'Types of Structure', 4)";
    public static string InsertPolymersIntoTopic = "INSERT INTO Topics(Id, TopicName, SubjectId) VALUES (15, 'Polymers', 4)";



    //The data required in the topics table
    public static List<string> InsertIntoTopicsQueries = new List<string>
    {
        //Maths
        InsertFactorsIntoTopic,
        InsertNumbersIntoTopic,
        InsertFractionsIntoTopic,
        InsertPercentagesIntoTopic,
        InsertTrigonometryIntoTopic,

        //English
        InsertEnglishTermsIntoTopic,
        InsertRomJulCharsIntoTopic,

        //Physics
        InsertSpecificHeatCapacityIntoTopic,
        InsertElectricityIntoTopic,
        InsertForcesIntoTopic,
        InsertVisibleLightIntoTopic,

        //Chemistry
        InsertAtomicStructureIntoTopic,
        InsertMetallicBondingIntoTopic,
        InsertTypesOfStructureIntoTopic,
        InsertPolymersIntoTopic
                
    };

    //Maths
    public static string InsertQuestion1IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (1, 'What are the factors of 30?', '1, 2, 3, 5, 6, 10, 15, 30', 1)";
    public static string InsertQuestion2IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (2, 'What are the common factors of 12 and 18?', '1, 2, 3, 6', 1)";
    public static string InsertQuestion3IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (3, 'What is the prime factorization of 48?', '2 x 2 x 2 x 2 x 3', 1)";
    public static string InsertQuestion4IntoFactors = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (4, 'What is the greatest common factor of 16 and 24?', '8', 1)";

    public static string InsertQuestion1IntoNumbers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (5, 'What is an index(indices)?', 'The amount many times the base number is multiplied by itself', 2)";
    public static string InsertQuestion2IntoNumbers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (6, 'What is a base number?', 'The number to be raised by the index', 2)";
    public static string InsertQuestion3IntoNumbers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (7, 'What is an integer?', 'All whole numbers(positive and negative) including zero', 2)";   
    public static string InsertQuestion4IntoNumbers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (8, 'What does BIDMAS stand for?', 'An acronym to remember the order for Brackets, Indices, Division, Multiplication, Addition and Subtraction', 2)";
    public static string InsertQuestion5IntoNumbers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (9, 'What are the 4 operations?', 'A mathematical process such as Addition, Subtraction, Multiplication and Division', 2)";

    public static string InsertQuestion1IntoFractions = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (10, 'A numerator is...?', 'The top number in a fraction', 3)";
    public static string InsertQuestion2IntoFractions = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (11, 'A denominator is...?', 'The bottom number in a fraction', 3)";
    public static string InsertQuestion3IntoFractions = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (12, 'What is a fraction?', 'A part of a whole e.g. 15/6 or 6/3', 3)";
    public static string InsertQuestion4IntoFractions = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (13, 'What is a mixed number?', 'A whole number and a fraction e.g. 4 3/4 or 1 5/8', 3)";
    public static string InsertQuestion5IntoFractions = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (14, 'What is an improper fraction?', 'A fraction whose numerator is larger than its denominator e.g. 16/5 or 7/3', 3)";

    public static string InsertQuestion1IntoPercentages = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (15, 'What is a percentage?', 'A portion of 100', 4)";
    public static string InsertQuestion2IntoPercentages = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (16, 'What is the formula for percentage change?', 'change / original X 100', 4)";
    public static string InsertQuestion3IntoPercentages = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (17, 'How do you find 1% of a number?', 'Divide by 100', 4)";
    public static string InsertQuestion4IntoPercentages = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (18, 'How do you convert a decimal to a percentage?', 'Multiply by 100', 4)";
    public static string InsertQuestion5IntoPercentages = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (19, 'What is compound interest?', 'Earning interest on interest', 4)";
    
    public static string InsertQuestion1IntoTrigonometry = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (20, 'What is Pythagoras'' Theorem?', 'a^2 + b^2 = c^2', 5)";
    public static string InsertQuestion2IntoTrigonometry = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (21, 'What are the edges of a right-angled triangle called?', 'Hypotenuse, Opposite and Adjacent', 5)";
    public static string InsertQuestion3IntoTrigonometry = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (22, 'What is the acronym for the trigonometry functions?', 'SOH CAH TOA', 5)";
    public static string InsertQuestion4IntoTrigonometry = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (23, 'What is the sin ratio?', 'sin = opposite / hypotenuse', 5)";
    public static string InsertQuestion5IntoTrigonometry = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (24, 'What is the tan ratio?', 'cos = adjacent / hypotenuse', 5)";

    //English
    public static string InsertQuestion1IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (25, 'What is Alliteration?', 'The repetition of the same letter or sound with adjacent words.', 6)";
    public static string InsertQuestion2IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (26, 'What is Genre?', 'A particular type of writing e.g. poetry, drama.', 6)";
    public static string InsertQuestion3IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (27, 'What is Personification?', 'Where human qualities are given to objects or abstract ideas.', 6)";
    public static string InsertQuestion4IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (28, 'What is a Metaphor?', 'A comparison where one thing IS another thing.', 6)";
    public static string InsertQuestion5IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (29, 'What is a Simile?', 'A comparison where one thing is LIKE or AS something else.', 6)";
    public static string InsertQuestion6IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (30, 'What is Onomatopoeia?', 'The use of a word whose sound copies what is named.', 6)";
    public static string InsertQuestion7IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (31, 'What is a Narrative?', 'A piece of writing that tells a story.', 6)";
    public static string InsertQuestion8IntoEnglishTerms = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (32, 'What is a Protagonist?', 'The main character or speaker in a poem, play or story.', 6)";

    public static string InsertQuestion1IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (33, 'The female protagonist, who is the only daughter of Lord and Lady Capulet.', 'Juliet', 7)";
    public static string InsertQuestion2IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (34, 'The head of the family and Juliet''s protective father.', 'Lord Capulet', 7)";
    public static string InsertQuestion3IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (35, 'The male protagonist, who is the son of Lord and Lady Montague.', 'Romeo', 7)";
    public static string InsertQuestion4IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (36, 'A single character who functions as the narrator.', 'The Chorus', 7)";
    public static string InsertQuestion5IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (37, 'The Prince of Verona, concerned about maintaining peace at all costs.', 'Prince Escalus', 7)";
    public static string InsertQuestion6IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (38, 'The reserved head of the family and Romeo''s father.', 'Lord Montague', 7)";
    public static string InsertQuestion7IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (39, 'Juliet''s cold and absent mother who consider marriage in terms of social status.', 'Lady Capulet', 7)";
    public static string InsertQuestion8IntoRomJulChars = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (40, 'Romeo''s mother who dislikes violence between the families.', 'Lady Montague', 7)";

    //Physics
    public static string InsertQuestion1IntoSpecificHeatCapacity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (41, 'What is Specific Heat Capacity(SHC)?', 'The energy required to raise the temperature of 1kg of a substance by 1 degree celsius.', 8)";
    public static string InsertQuestion2IntoSpecificHeatCapacity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (42, 'What is Temperature?', 'Temperature is the measure of the average kinetic energy of particles in a substance.', 8)";
    public static string InsertQuestion3IntoSpecificHeatCapacity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (43, 'What are Joules(J)?', 'The SI unit for energy and work.', 8)";
    public static string InsertQuestion4IntoSpecificHeatCapacity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (44, 'Thermal Conductors are...?', 'Materials with a low specific heat capacity, so heat up and cool down QUICKLY.', 8)";
    public static string InsertQuestion5IntoSpecificHeatCapacity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (45, 'Thermal Insulators are...?', 'Materials with a high specific heat capacity, so heat up and cool down SLOWLY.', 8)";

    public static string InsertQuestion1IntoElectricity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (46, 'What is Alternating Potential Difference?', 'A potential difference that continually reverses its direction.', 9)";
    public static string InsertQuestion2IntoElectricity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (47, 'What is Direct Potential Difference?', 'A potential difference that only acts in one direction.', 9)";
    public static string InsertQuestion3IntoElectricity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (48, 'What is Alternating Current(AC)?', 'An electric current which flows consistently in one direction around a circuit e.g. Power Stations', 9)";
    public static string InsertQuestion4IntoElectricity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (49, 'What is Direct Current(DC)?', 'An electric current that continually reverses direction and changes sizes e.g. Solar Cells', 9)";
    public static string InsertQuestion5IntoElectricity = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (50, 'What is Hertz(Hz)?', 'The SI unit for frequency.', 9)";

    public static string InsertQuestion1IntoForces = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (51, 'What is Mass?', 'A measure of the amount of matter in an object.', 10)";
    public static string InsertQuestion2IntoForces = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (52, 'What is Weight?', 'The force acting on an object due to gravity.', 10)";
    public static string InsertQuestion3IntoForces = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (53, 'What is the relation between weight and mass?', 'The weight of an object is directly proportional to its mass.', 10)";
    public static string InsertQuestion4IntoForces = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (54, 'What are Newtons(N)?', 'The SI unit for force.', 10)";
    public static string InsertQuestion5IntoForces = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (55, 'What are Kilograms(kg)?', 'The SI unit for mass.', 10)";

    public static string InsertQuestion1IntoVisibleLight = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (56, 'The visible light spectrum is...?', 'A spectrum of colour within the electromagnetic spectrum.', 11)";
    public static string InsertQuestion2IntoVisibleLight = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (57, 'What are the colours in order of increasing frequency?', 'Red, Orange, Yellow, Green, Blue, Indigo, Violet.', 11)";
    public static string InsertQuestion3IntoVisibleLight = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (58, 'What is Transmission of light?', 'When light continues to travel through the material.', 11)";
    public static string InsertQuestion4IntoVisibleLight = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (59, 'What are Transparent materials?', 'Materials that transmit light with very little absorption.', 11)";
    public static string InsertQuestion5IntoVisibleLight = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (60, 'What are Translucent materials?', 'Materials that transmit some light with some absorption.', 11)";

    //Chemistry
    public static string InsertQuestion1IntoAtomicStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (61, 'How many electrons can the first shell hold?', '2 electrons', 12)";
    public static string InsertQuestion2IntoAtomicStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (62, 'How many electrons can the second shell hold?', '8 electrons', 12)";
    public static string InsertQuestion3IntoAtomicStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (63, 'The No. of shells equals...?', 'Period on the periodic table.', 12)";
    public static string InsertQuestion4IntoAtomicStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (64, 'What are the ''Valence'' electrons?', 'Outer shell electrons which participate in reactions.', 12)";
    public static string InsertQuestion5IntoAtomicStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (65, 'Nitrogen electron structure?', '2, 5', 12)";
    
    public static string InsertQuestion1IntoMetallicBonding = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (66, 'What is a Delocalised Electron?', 'An electron that can movefreely throughout the structure.', 13)";
    public static string InsertQuestion2IntoMetallicBonding = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (67, 'What are Positive Metal Ions?', 'Metal atoms that have lost their outer electrons.', 13)";
    public static string InsertQuestion3IntoMetallicBonding = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (68, 'What is Metallic Bonding?', 'A lattice os positive metal ions surronded by delocalised outer electrons, held together by strong electrostatic forces of attraction.', 13)";
    public static string InsertQuestion4IntoMetallicBonding = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (69, 'What is a Lattice?', 'A regular arrangement of particles.', 13)";
    public static string InsertQuestion5IntoMetallicBonding = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (70, 'What are Electrostatic Forces of Attraction?', 'Strong forces of attraction between oppositely charged particles.', 13)";

    public static string InsertQuestion1IntoTypesOfStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (71, 'What is an Ion?', 'An atom or group of atoms that have lost or gained electrons and therefore have gained a positive or negative charge.', 14)";
    public static string InsertQuestion2IntoTypesOfStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (72, 'What is a Polyatomic Ion?', 'An ion that is made of more than one atom.', 14)";
    public static string InsertQuestion3IntoTypesOfStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (73, 'What is a Metal Ion?', 'An atom which has lost electrons forming a positive ion.', 14)";
    public static string InsertQuestion4IntoTypesOfStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (74, 'What is a Non-Metal Ion?', 'An atom which has gained electrons forming a negative ion.', 14)";
    public static string InsertQuestion5IntoTypesOfStructure = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (75, 'What is a Covalent Bond?', 'A shared pair of electrons.', 14)";

    public static string InsertQuestion1IntoPolymers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (76, 'What are Monomers?', 'A small molecule that can join with other small molecules to form polymers.', 15)";
    public static string InsertQuestion2IntoPolymers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (77, 'What are Polymers?', 'Long molecules made by joining lots of monomers.', 15)";
    public static string InsertQuestion3IntoPolymers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (78, 'What are Plastics?', 'Synthetic polymers that can be moulded or shaped.', 15)";
    public static string InsertQuestion4IntoPolymers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (79, 'How do you name a polymer?', 'Named as ''Poly(Monomer)''.', 15)";
    public static string InsertQuestion5IntoPolymers = "INSERT INTO Flashcards(Id, Question, Answer, TopicId) VALUES (80, 'What are Amino Acids?', 'Monomers of proteins.', 15)";



    public static List<string> InsertIntoFlashcardsQueries = new List<string>
    {
        //Maths
        InsertQuestion1IntoFactors,
        InsertQuestion2IntoFactors,
        InsertQuestion3IntoFactors,
        InsertQuestion4IntoFactors,

        InsertQuestion1IntoNumbers,
        InsertQuestion2IntoNumbers,
        InsertQuestion3IntoNumbers,
        InsertQuestion4IntoNumbers,
        InsertQuestion5IntoNumbers,

        InsertQuestion1IntoFractions,
        InsertQuestion2IntoFractions,
        InsertQuestion3IntoFractions,
        InsertQuestion4IntoFractions,
        InsertQuestion5IntoFractions,

        InsertQuestion1IntoPercentages,
        InsertQuestion2IntoPercentages,
        InsertQuestion3IntoPercentages,
        InsertQuestion4IntoPercentages,
        InsertQuestion5IntoPercentages,

        InsertQuestion1IntoTrigonometry,
        InsertQuestion2IntoTrigonometry,
        InsertQuestion3IntoTrigonometry,
        InsertQuestion4IntoTrigonometry,
        InsertQuestion5IntoTrigonometry,

        //English
        InsertQuestion1IntoEnglishTerms,
        InsertQuestion2IntoEnglishTerms,
        InsertQuestion3IntoEnglishTerms,
        InsertQuestion4IntoEnglishTerms,
        InsertQuestion5IntoEnglishTerms,
        InsertQuestion6IntoEnglishTerms,
        InsertQuestion7IntoEnglishTerms,
        InsertQuestion8IntoEnglishTerms,

        InsertQuestion1IntoRomJulChars,
        InsertQuestion2IntoRomJulChars,
        InsertQuestion3IntoRomJulChars,
        InsertQuestion4IntoRomJulChars,
        InsertQuestion5IntoRomJulChars,
        InsertQuestion6IntoRomJulChars,
        InsertQuestion7IntoRomJulChars,
        InsertQuestion8IntoRomJulChars,

        //Physics
        InsertQuestion1IntoSpecificHeatCapacity,
        InsertQuestion2IntoSpecificHeatCapacity,
        InsertQuestion3IntoSpecificHeatCapacity,
        InsertQuestion4IntoSpecificHeatCapacity,
        InsertQuestion5IntoSpecificHeatCapacity,

        InsertQuestion1IntoElectricity,
        InsertQuestion2IntoElectricity,
        InsertQuestion3IntoElectricity,
        InsertQuestion4IntoElectricity,
        InsertQuestion5IntoElectricity,

        InsertQuestion1IntoForces,
        InsertQuestion2IntoForces,
        InsertQuestion3IntoForces,
        InsertQuestion4IntoForces,
        InsertQuestion5IntoForces,

        InsertQuestion1IntoVisibleLight,
        InsertQuestion2IntoVisibleLight,
        InsertQuestion3IntoVisibleLight,
        InsertQuestion4IntoVisibleLight,
        InsertQuestion5IntoVisibleLight,

        //Chemistry
        InsertQuestion1IntoAtomicStructure,
        InsertQuestion2IntoAtomicStructure,
        InsertQuestion3IntoAtomicStructure,
        InsertQuestion4IntoAtomicStructure,
        InsertQuestion5IntoAtomicStructure,

        InsertQuestion1IntoMetallicBonding,
        InsertQuestion2IntoMetallicBonding,
        InsertQuestion3IntoMetallicBonding,
        InsertQuestion4IntoMetallicBonding,
        InsertQuestion5IntoMetallicBonding,

        InsertQuestion1IntoTypesOfStructure,
        InsertQuestion2IntoTypesOfStructure,
        InsertQuestion3IntoTypesOfStructure,
        InsertQuestion4IntoTypesOfStructure,
        InsertQuestion5IntoTypesOfStructure,

        InsertQuestion1IntoPolymers,
        InsertQuestion2IntoPolymers,
        InsertQuestion3IntoPolymers,
        InsertQuestion4IntoPolymers,
        InsertQuestion5IntoPolymers


    };


    public static string GetAllSubjects = "SELECT * FROM Subjects";
    public static string GetAllTopics = "SELECT * FROM Topics WHERE SubjectId = ";

}
