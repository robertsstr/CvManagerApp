function addEducation() {
    var educationFields = document.getElementById("educationFields");
    var educationCount = educationFields.getElementsByClassName("education").length;
    var newEducationField = document.createElement("div");
    newEducationField.classList.add("education");
    newEducationField.innerHTML = `
                <div class="form-group">
                    <label>mācību iestāde:</label>
                    <input type="text" name="Educations[${educationCount}].EducationalEstablishment" class="form-control">
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
                    <input type="text" name="Educations[${educationCount}].StudyStatus" class="form-control">
                </div>
                <input type="hidden" name="Educations[${educationCount}].Id" value="">
                <button type="button" class="btn btn-danger" onclick="deleteEducation(this)">dzēst</button>
            `;
    educationFields.appendChild(newEducationField);
}

async function deleteEducation(button, educationId) {
    var educationDiv = button.closest(".education");
    const response = await fetch(`/education/delete/${educationId}`, {
        method: 'DELETE'
    });
    educationDiv.remove();
}

function addWorkExperience() {
    var workExperienceFields = document.getElementById("workExperienceFields");
    var workExperienceCount = workExperienceFields.getElementsByClassName("work-experience").length;
    var newWorkExperienceField = document.createElement("div");
    newWorkExperienceField.classList.add("work-experience");
    newWorkExperienceField.innerHTML = `
                <div class="form-group">
                    <label>uzņēmums:</label>
                    <input type="text" name="WorkExperiences[${workExperienceCount}].Company" class="form-control">
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
                <input type="hidden" name="WorkExperiences[${workExperienceCount}].Id" value="">
                <button type="button" class="btn btn-danger" onclick="deleteWorkExperience(this)">dzēst</button>
            `;
    workExperienceFields.appendChild(newWorkExperienceField);
}

async function deleteWorkExperience(button, workExperienceId) {
    var workExperienceDiv = button.closest(".work-experience");
    const response = await fetch(`/workexperience/delete/${workExperienceId}`, {
        method: 'DELETE'
    });
    workExperienceDiv.remove();
}

function addSkillAchievement() {
    var skillAchievementFields = document.getElementById("skillAchievementFields");
    var skillAchievementCount = skillAchievementFields.getElementsByClassName("skill-achievement").length;
    var newSkillAchievementField = document.createElement("div");
    newSkillAchievementField.classList.add("skill-achievement");
    newSkillAchievementField.innerHTML = `
                <div class="form-group">
                    <label>prasme/sasniegums:</label>
                    <input type="text" name="SkillsAchievements[${skillAchievementCount}].SkillOrAchievement" class="form-control" required>
                </div>
                <input type="hidden" name="SkillsAchievements[${skillAchievementCount}].Id" value="">
                <button type="button" class="btn btn-danger" onclick="deleteSkillAchievement(this)">dzēst</button>
            `;
    skillAchievementFields.appendChild(newSkillAchievementField);
}

async function deleteSkillAchievement(button, skillAchievementId) {
    var skillAchievementDiv = button.closest(".skill-achievement");
    const response = await fetch(`/skillachievement/delete/${skillAchievementId}`, {
        method: 'DELETE'
    });
    skillAchievementDiv.remove();
}