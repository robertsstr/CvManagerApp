function addEducation() {
    var educationCount = 0;
    var educationFields = document.getElementById("educationFields");
    var newEducationField = document.createElement("div");
    newEducationField.classList.add("education");
    newEducationField.innerHTML = `
            <div class="form-group">
                <label>mācību iestāde:</label>
                <input type="text" name="Educations[${educationCount}].EducationalEstablishment" class="form-control" required>
            </div>
            <div class="form-group">
                <label>fakultāte:</label>
                <input type="text" name="Educations[${educationCount}].Faculty" class="form-control">
            </div>
            <div class="form-group">
                <label>studiju programma:</label>
                <input type="text" name="Educations[${educationCount}].StudyProgram" class="form-control">
            </div>
            <div class="form-group">
                <label>mācību status:</label>
                <input type="text" name="Educations[${educationCount}].StudyStatus" class="form-control" required>
            </div>
            <input type="hidden" name="Educations[${educationCount}].Id" value="">
            <button type="button" class="btn btn-danger" onclick="deleteEducation(this)">dzēst</button>
        `;
    educationFields.appendChild(newEducationField);
    educationCount++;
}

async function deleteEducation(button, educationId) {
    var educationDiv = button.closest(".education");
    educationDiv.remove();
}

function addWorkExperience() {
    var workExperienceCount = 0;
    var workExperienceFields = document.getElementById("workExperienceFields");
    var newWorkExperienceField = document.createElement("div");
    newWorkExperienceField.classList.add("work-experience");
    newWorkExperienceField.innerHTML = `
            <div class="form-group">
                <label>uzņēmums:</label>
                <input type="text" name="WorkExperiences[${workExperienceCount}].Company" class="form-control" required>
            </div>
            <div class="form-group">
                <label>amats:</label>
                <input type="text" name="WorkExperiences[${workExperienceCount}].Position" class="form-control">
            </div>
            <div class="form-group">
                <label>sākuma datums:</label>
                <input type="date" name="WorkExperiences[${workExperienceCount}].StartDate" class="form-control">
            </div>
            <div class="form-group">
                <label>beigu datums:</label>
                <input type="date" name="WorkExperiences[${workExperienceCount}].EndDate" class="form-control">
            </div>
            <button type="button" class="btn btn-danger" onclick="deleteWorkExperience(this)">dzēst</button>
        `;
    workExperienceFields.appendChild(newWorkExperienceField);
    workExperienceCount++;
}

function deleteWorkExperience(button) {
    var workExperienceDiv = button.closest(".work-experience");
    workExperienceDiv.remove();
}

function addSkillAchievement() {
    var skillAchievementCount = 0;
    var skillAchievementFields = document.getElementById("skillAchievementFields");
    var newSkillAchievementField = document.createElement("div");
    newSkillAchievementField.classList.add("skill-achievement");
    newSkillAchievementField.innerHTML =
        `<div class="form-group">
                <label>prasme vai sasniegums:</label>
                <input type="text" name="SkillsAchievements[${skillAchievementCount}].SkillOrAchievement" class="form-control" required>
            </div>
            <button type="button" class="btn btn-danger" onclick="deleteSkillAchievement(this)">dzēst</button>`;
    skillAchievementFields.appendChild(newSkillAchievementField);
    skillAchievementCount++;
}
function deleteSkillAchievement(button) {
    var skillAchievementDiv = button.closest(".skill-achievement");
    skillAchievementDiv.remove();
}