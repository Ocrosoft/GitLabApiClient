﻿using System;
using System.Collections.Generic;
using GitLabApiClient.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GitLabApiClient.Models.Issues
{
    /// <summary>
    /// Used to update issues in a project.
    /// </summary>
    public sealed class UpdateIssueRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateIssueRequest"/> class.
        /// </summary>
        /// <param name="projectId">The ID or URL-encoded path of the project owned by the authenticated user.</param>
        /// <param name="issueId">The internal ID of a project's issue.</param>
        public UpdateIssueRequest(string projectId, int issueId)
        {
            Guard.NotEmpty(projectId, nameof(projectId));
            ProjectId = projectId;
            IssueId = issueId;
        }

        /// <summary>
        /// The ID or URL-encoded path of the project owned by the authenticated user.
        /// </summary>
        [JsonProperty("id")]
        public string ProjectId { get; }

        /// <summary>
        /// The internal ID of a project's issue.
        /// </summary>
        [JsonProperty("issue_iid")]
        public int IssueId { get; }

        /// <summary>
        /// The title of an issue.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The description of an issue.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Updates an issue to be confidential.
        /// </summary>
        [JsonProperty("confidential")]
        public bool Confidential { get; set; }

        /// <summary>
        /// The ID of the users to assign the issue to.
        /// </summary>
        [JsonProperty("assignee_ids")]
        public List<int> Assignees { get; set; } = new List<int>();

        /// <summary>
        /// The ID of a milestone to assign the issue to.
        /// </summary>
        [JsonProperty("milestone_id")]
        public int? MilestoneId { get; set; }

        /// <summary>
        /// Label names for an issue.
        /// </summary>
        [JsonProperty("labels")]
        [JsonConverter(typeof(CollectionToCommaSeparatedValuesConverter))]
        public IList<string> Labels { get; set; } = new List<string>();

        /// <summary>
        /// The state event of an issue. Set close to close the issue and reopen to reopen it.
        /// </summary>
        [JsonProperty("state_event")]
        [JsonConverter(typeof(StringEnumConverter))]
        public UpdatedIssueState? State { get; set; }

        /// <summary>
        /// Date time string, ISO 8601 formatted, e.g. 2016-03-11T03:45:40Z (requires admin or project owner rights).
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Date time string in the format YEAR-MONTH-DAY, e.g. 2016-03-11.
        /// </summary>
        [JsonProperty("due_date")]
        public string DueDate { get; set; }
    }
}